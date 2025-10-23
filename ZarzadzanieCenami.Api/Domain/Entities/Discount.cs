using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieCenami.Api.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(120)]
        public string Description { get; set; } = null!;

        [Column(TypeName = "timestamp with time zone")]
        public DateTime ExpirationDate { get; set; }

        public decimal Percentage { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
