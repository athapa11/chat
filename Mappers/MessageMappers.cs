using DashApi.Dtos.Message;
using DashApi.Models;

namespace DashApi.Mappers
{
    // map createDto to message to post
    public static class MessageMappers
    {
        public static MessageDto ToMessageDto(this Message messageModel){
            return new MessageDto{
                Id = messageModel.Id,
                Content = messageModel.Content,
                CreatedOn = messageModel.CreatedOn,
                Edited = messageModel.Edited,
                ChatId = messageModel.ChatId,
                UserId = messageModel.UserId
            };
        }

        
        // mapping for post request
        public static Message ToMessageFromDto(this CreateMessageDto messageDto, int chatId){
            return new Message{
                Content = messageDto.Content,
                ChatId = chatId
            };
        }
    }
}