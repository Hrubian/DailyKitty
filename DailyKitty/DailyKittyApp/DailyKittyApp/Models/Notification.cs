using System;

namespace DailyKittyApp.Models
{
    internal class Notification
    {
        public DateTime When { get; set; }
        public Guid CatId { get; set; }
        public bool Important { get; set; }
        public bool Canceled { get; set; }
        public string Description { get; set; }
    }
}
