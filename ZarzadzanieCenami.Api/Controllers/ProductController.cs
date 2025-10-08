using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZarzadzanieCenami.Api.Application.Requests;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;
using ZarzadzanieCenami.Api.Infrastructure.Persistence;

namespace ZarzadzanieCenami.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public ProductController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetProducts))]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _dbContext.Products
                .Include(p => p.Prices)
                .Include(p => p.Discounts)
                .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpGet(nameof(GetShops))]
        public async Task<IEnumerable<ShopDto>> GetShops()
        {
            var shops = await _dbContext.Shops
                .Include(s => s.Address)
                .ToListAsync();

            return _mapper.Map<List<ShopDto>>(shops);
        }

        [HttpGet("GetProductsByShop/{shopId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByShop(int shopId)
        {
            if (shopId <= 0)
                return BadRequest("Invalid shopId.");

            var products = await _dbContext.Products
                .Include(p => p.Prices)
                .Include(p => p.Discounts)
                .Where(p => p.Shops.Any(s => s.Id == shopId))
                .ToListAsync();

            if (products == null || !products.Any())
                return NotFound($"No products found for shopId = {shopId}.");

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpPost(nameof(AddProduct))]
        public async Task<ActionResult> AddProduct([FromBody] ProductRequest dto)
        {
            Shop? shop = await _dbContext.Shops
                .FirstOrDefaultAsync(s => s.Id == dto.ShopId);

            if (shop == null)
                return NotFound($"No shop found for shopId = {dto.ShopId}.");

            Product product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Prices = _mapper.Map<List<Price>>(dto.Prices),
                Shops = new List<Shop> { shop }
            };

            _dbContext.Products.Add(product);

            return Ok(await _dbContext.SaveChangesAsync());
        }

        [HttpPost(nameof(AddDiscount))]
        public async Task<ActionResult> AddDiscount([FromBody] DiscountRequest dto)
        {
            Product? product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

            Shop? shop = await _dbContext.Shops
                .FirstOrDefaultAsync(s => s.Id == dto.ShopId);

            if (product == null || shop == null)
                return NotFound($"No shop or product found for shopId = {dto.ShopId} or productId = {dto.ProductId}.");

            Discount discount = _mapper.Map<Discount>(dto);

            _dbContext.Discounts.Add(discount);

            return Ok(await _dbContext.SaveChangesAsync());
        }
    }
}
