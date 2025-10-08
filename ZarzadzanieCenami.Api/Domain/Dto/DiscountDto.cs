

namespace ZarzadzanieCenami.Api.Domain.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;
        public decimal Percentage { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}
