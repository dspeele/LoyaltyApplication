using Microsoft.EntityFrameworkCore;

namespace LoyaltyApplication.Models
{
    public class LoyaltyContext : DbContext {
        public LoyaltyContext(DbContextOptions<LoyaltyContext> options)
            : base(options) {
        }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
