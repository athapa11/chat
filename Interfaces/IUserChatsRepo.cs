using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Models;

namespace DashApi.Interfaces
{
    public interface IUserChatsRepo
    {
        Task<List<Chat>> GetUserChats(User user);
    }
}