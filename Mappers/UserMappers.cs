using DashApi.Dtos;
using DashApi.Models;

namespace DashApi.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.Username,
                CreatedOn = userModel.CreatedOn
            };
        }
    }
}