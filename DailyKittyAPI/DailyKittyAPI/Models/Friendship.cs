using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyKittyAPI.Models
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int RequestorId { get; set; }
        [ForeignKey("RequestorId")]
        public User Requestor { get; set; }

        public int RequesteeId { get; set; }
        [ForeignKey("RequesteeId")]
        public User Requestee { get; set; }

        public string Status { get; set; }
    }
}
