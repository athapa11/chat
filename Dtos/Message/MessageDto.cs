namespace DashApi.Dtos.Message
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}