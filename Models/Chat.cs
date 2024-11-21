namespace DashApi.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<Message> Messages { get; set; } = new List<Message>();
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}