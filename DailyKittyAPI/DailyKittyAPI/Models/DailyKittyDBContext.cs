using Microsoft.EntityFrameworkCore;

namespace DailyKittyAPI.Models
{
    public class DailyKittyDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
