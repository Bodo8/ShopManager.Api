namespace ZarzadzanieCenami.Api.Domain.Entities
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Address Address { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
