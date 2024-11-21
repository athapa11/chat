namespace DashApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // activity
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastOnline { get; set; } = DateTime.Now;

        // relationship
        // public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
