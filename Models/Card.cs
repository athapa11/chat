namespace DashApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int SortCode { get; set; }
        public int AccountNumber { get; set; }
    }
}
