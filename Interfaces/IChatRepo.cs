using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DashApi.Interfaces
{
    public interface IChatRepo
    {
        Task<List<Chat>> GetAllAsync();

        Task<Chat?> GetByIdAsync(int id);

        Task<Chat> CreateChatAsync(Chat chat);

        Task<Chat?> EditChatAsync(int id, Chat chat);

        Task<Chat?> DeleteChatAsync(int id);
    }
}