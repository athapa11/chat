using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashApi.Dtos.Chat
{
    public class ChatDto
    {
        public int Id { get; set; }
        public string ChatName { get; set; } = string.Empty;

        // activity
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // relationships
        //public List<Message> Messages { get; set; } = new List<Message>();

        public int? UserId { get; set; }
    }
}