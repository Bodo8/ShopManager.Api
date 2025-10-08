

namespace ZarzadzanieCenami.Api.Domain.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string City { get; set; } = null!;

        public int ShopId { get; set; }
    }
}
