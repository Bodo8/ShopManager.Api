

namespace ZarzadzanieCenami.Api.Domain.Dto

{
    public class PriceDto
    {
        public int Id { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int ProductId { get; set; }
    }
}
