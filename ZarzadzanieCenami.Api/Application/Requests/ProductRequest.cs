using ZarzadzanieCenami.Api.Domain.Dto;

namespace ZarzadzanieCenami.Api.Application.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PriceDto> PricesDtos { get; set; } = new List<PriceDto>();
        public List<int> ShopIds { get; set; } = new List<int>();
        public List<DiscountDto>? DiscountDtos { get; set; }
    }
}
