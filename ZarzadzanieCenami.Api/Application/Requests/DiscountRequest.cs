namespace ZarzadzanieCenami.Api.Application.Requests
{
    public class DiscountRequest
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> ShopIds { get; set; }
    }
}
