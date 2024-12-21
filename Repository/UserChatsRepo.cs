using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Data;
using DashApi.Interfaces;
using DashApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashApi.Repository
{
    public class UserChatsRepo : IUserChatsRepo
    {
        private readonly DashDbContext _context;

        public UserChatsRepo(DashDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetUserChats(User user)
        {
            return await _context.UserChats.Where(u => u.UserId == user.Id)
                .Select(chat => new Chat
                {
                    Id = chat.ChatId,
                    ChatName = chat.Chat.ChatName,
                    CreatedOn = chat.Chat.CreatedOn,
                })
                .ToListAsync();
        }
    }
}