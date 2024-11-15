using DashApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Data
{
    public class DashDbContext : DbContext
    {
        public DashDbContext(DbContextOptions options) 
        : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}