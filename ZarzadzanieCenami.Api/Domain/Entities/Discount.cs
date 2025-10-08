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
        public decimal Percentage { get; set; }
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
        public Shop Shop { get; set; } = null!;
        public int ShopId { get; set; }
    }
}
