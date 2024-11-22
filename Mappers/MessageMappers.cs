using DashApi.Dtos.Message;
using DashApi.Models;

namespace DashApi.Mappers
{
    // map createDto to message to post
    public static class MessageMappers
    {
        public static Message ToMessageFromDto(this CreateMessageDto messageDto)
        {
            return new Message
            {
                Content = messageDto.Content
            };
        }
    }
}