using System.ComponentModel.DataAnnotations;

namespace DailyKittyAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string NickName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Joined { get; set; }
        public DateTime? Banned { get; set; }
        public bool IsAdmin { get; set; }
    }
}
