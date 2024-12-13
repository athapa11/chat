using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Data;
using Microsoft.AspNetCore.Identity;

namespace DashApi.Models
{
    public class User : IdentityUser
    {
        // activity
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastOnline { get; set; } = DateTime.Now;

        // relationship
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}