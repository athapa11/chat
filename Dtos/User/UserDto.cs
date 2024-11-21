namespace DashApi.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // activity
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastOnline { get; set; } = DateTime.Now;
    }
}