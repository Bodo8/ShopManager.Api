using System.ComponentModel.DataAnnotations.Schema;

namespace ZarzadzanieCenami.Api.Domain.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public decimal BasePrice { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime EffectiveDate { get; set; }
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
