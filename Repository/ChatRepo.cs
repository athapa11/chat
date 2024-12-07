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

        public ChatRepo(DashDbContext context){
            _context = context;
        }

        public async Task<List<Chat>> GetAllAsync(){
            return await _context.Chat.ToListAsync();
        }


        public async Task<Chat?> GetByIdAsync(int id){
            return await _context.Chat.FindAsync(id);
        }


        public async Task<Chat> CreateChatAsync(Chat chat){
            await _context.Chat.AddAsync(chat);
            await _context.SaveChangesAsync();
            return chat;
        }


        public Task<Chat?> DeleteChatAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Chat?> EditChatAsync(int id, Chat chat)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChatExists(int id)
        {
            return await _context.Chat.AnyAsync(s => s.Id == id);
        }
    }
}