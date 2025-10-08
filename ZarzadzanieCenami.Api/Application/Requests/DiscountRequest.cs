namespace ZarzadzanieCenami.Api.Application.Requests
{
    public class DiscountRequest
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;
        public decimal Percentage { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}
