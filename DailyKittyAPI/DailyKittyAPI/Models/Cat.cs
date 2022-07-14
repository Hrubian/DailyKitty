using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyKittyAPI.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Color { get; set; } //todo really a string? 
        public int CatOwnerId { get; set; }
        [ForeignKey("CatOwnerId")]
        public User CatOwner { get; set; }
        public DateTime? Removed { get; set; }
    }
}
