using DailyKittyAPI.Models;
using DailyKittyAPI.Services;
using DailyKittyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DailyKittyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "dailykittyapp", IgnoreApi = false)]
    public class UserController : Controller
    {
        private readonly DailyKittyDBContext _dbContext;
        public AuthenticationService _authService { get; }

        public UserController(DailyKittyDBContext dbContext,
            AuthenticationService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        

        [HttpPost("register")]
        public IActionResult Register ([FromBody]UserViewModel userVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (_dbContext.Users.Any(user => user.NickName == userVM.NickName))
                    return BadRequest("User with selected nickname already exists");

                var user = _authService.CreateUserToRegister(userVM);

                _dbContext.Users.Add(user);

                _dbContext.SaveChanges();

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost("login")]
        public ActionResult<string> Login ([FromBody]UserViewModel userVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var dbUser = _dbContext.Users.Where(user => user.NickName == userVM.NickName).FirstOrDefault();
                if (dbUser == null)
                    return BadRequest("Invalid credentials");

                if (!_authService.VerifyCredentials(userVM, dbUser))
                    return BadRequest("Invalid credentials");

                string jwtToken = _authService.GetToken(dbUser);

                return new OkObjectResult(jwtToken);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}
