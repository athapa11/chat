using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApi.Dtos.Chat;
using DashApi.Models;

namespace DashApi.Mappers
{
    public static class ChatMappers
    {
        public static ChatDto ToChatDto(this Chat chatModel)
        {
            return new ChatDto
            {
                Id = chatModel.Id,
                ChatName = chatModel.ChatName,
                CreatedOn = chatModel.CreatedOn,
                UserId = chatModel.UserId,
                Messages = chatModel.Messages.Select(m => m.ToMessageDto()).ToList()
            };
        }

        // public static Chat ToChatFromDto(this ChatDto dto)
        // {
        //     return new Chat
        //     {
        //         ChatName = dto.ChatName
        //     };
        // }
    }
}