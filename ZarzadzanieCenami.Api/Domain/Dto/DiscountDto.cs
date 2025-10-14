

namespace ZarzadzanieCenami.Api.Domain.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public decimal Percentage { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();
        public List<int> ShopIds { get; set; } = new List<int>();
    }
}
