using System.ComponentModel.DataAnnotations.Schema;
namespace DashApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int Stock { get; set; }
        public string Industry { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}