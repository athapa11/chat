using DashApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Data
{
    public class DashDbContext : IdentityDbContext<User>
    {
        public DashDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add user to model
            builder.Entity<User>();
        }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}