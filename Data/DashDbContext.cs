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
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}