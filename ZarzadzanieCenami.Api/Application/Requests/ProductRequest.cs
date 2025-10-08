using ZarzadzanieCenami.Api.Domain.Dto;

namespace ZarzadzanieCenami.Api.Application.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PriceDto> Prices { get; set; } = new List<PriceDto>();
        public int ShopId { get; set; }
    }
}
