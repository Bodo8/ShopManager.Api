using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieCenami.Api.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string City { get; set; } = null!;

        public Shop Shop { get; set; } = null!;
        public int ShopId { get; set; }
    }
}
