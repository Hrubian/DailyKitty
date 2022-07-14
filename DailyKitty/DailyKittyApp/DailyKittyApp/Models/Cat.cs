using System;
using System.Collections.Generic;
using System.Text;

namespace DailyKittyApp.Models
{
    internal class Cat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
