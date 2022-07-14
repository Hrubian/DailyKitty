using DailyKittyAPI.Models;
using DailyKittyAPI.Utils;
using DailyKittyAPI.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DailyKittyAPI.Services
{
    public class AuthenticationService
    {


        public User CreateUserToRegister(UserViewModel userVM)
        {
            var user = new User();
            using (var hmac = new HMACSHA512())
            {
                user.NickName = userVM.NickName;
                user.IsAdmin = false;
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userVM.Password));
            }

            return user;
        }

        public bool VerifyCredentials (UserViewModel userVM, User dbUser)
        {
            using (var hmac = new HMACSHA512())
            {
                var currentHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userVM.Password));
                return currentHash == dbUser.PasswordHash;
            }
        }

        public string GetToken(User dbUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dbUser.NickName),
                new Claim(ClaimTypes.Role, dbUser.IsAdmin ? UserRoles.Admin : UserRoles.Normal),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes());
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(3),
                signingCredentials: credentials
                );

            var jwtString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return jwtString;
        }
    }
}
