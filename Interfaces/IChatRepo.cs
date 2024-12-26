using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Dtos.Chat;
using DashApi.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DashApi.Interfaces
{
    public interface IChatRepo
    {
        Task<List<Chat>> GetUserChatsAsync(User user);

        Task<Chat?> GetByIdAsync(int id);

        Task<UserChat> CreateAssociationAsync(UserChat userChat);
        Task<Chat> CreateChatAsync(Chat chat);

        Task<Chat?> EditChatAsync(int id, Chat chat);

        Task<Chat?> DeleteChatAsync(int id);

        Task<bool> ChatExists(int id);
    }
}