

using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Dto
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
