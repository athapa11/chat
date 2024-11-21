using DashApi.Dtos.User;
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
                Email = userModel.Email,
                CreatedOn = userModel.CreatedOn,
                LastOnline = userModel.LastOnline
            };
        }

        public static User ToUserFromDto(this CreateUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                Email = userDto.Email
            };
        }
    }
}