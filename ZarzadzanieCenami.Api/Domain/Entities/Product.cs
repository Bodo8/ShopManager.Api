using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieCenami.Api.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "VARCHAR")]
        [StringLength(120)]
        public string Description { get; set; } = null!;
        public ICollection<Price> Prices { get; set; } = new List<Price>();
        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
