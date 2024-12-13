using DashApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Data
{
    public class DashDbContext : IdentityDbContext
    {
        public DashDbContext(DbContextOptions options) 
        : base(options)
        {
            
        }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}