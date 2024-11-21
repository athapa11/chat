namespace DashApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? ChatId { get; set; }
        public Chat? Chat { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}