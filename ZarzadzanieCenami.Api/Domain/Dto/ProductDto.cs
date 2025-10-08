
namespace ZarzadzanieCenami.Api.Domain.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public List<PriceDto> Prices { get; set; } = new List<PriceDto>();
        public List<DiscountDto> Discounts { get; set; } = new List<DiscountDto>();
        public List<ShopDto> Shops { get; set; } = new List<ShopDto>();
    }
}
