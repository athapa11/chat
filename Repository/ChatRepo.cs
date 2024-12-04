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
    public class ChatRepo : IChatRepo
    {
        private readonly DashDbContext _context;

        public ChatRepo(DashDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetAllAsync()
        {
            return await _context.Chat.ToListAsync();
        }

        public Task<Chat?> GetByIdAsync(int id)
        {
            //return await _context.Chat.FirstOrDefaultAsync(x => x.Id == x.id);
            throw new NotImplementedException();
        }

        public Task<Chat> CreateChatAsync(Chat chat)
        {
            //var chat = _context.
            throw new NotImplementedException();
        }

        public Task<Chat?> DeleteChatAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Chat?> EditChatAsync(int id, Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}