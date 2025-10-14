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
                .Include(d => d.Discounts)
                .Where(p => p.Shops.Any(s => s.Id == shopId)
                            && p.Discounts.Any(d => d.Shops.Any(x => x.Id == shopId)))
                .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        [HttpPost(nameof(AddProduct))]
        public async Task<ActionResult> AddProduct([FromBody] ProductRequest dto)
        {
            if (dto == null || dto.ShopIds.Count == 0)
                return BadRequest("Invalid product data or shopsId.");

            List<int> shopIds = dto.ShopIds;

            List<Shop> shops = await _dbContext.Shops
                .Where(s => shopIds.Contains(s.Id))
                .ToListAsync();

            if (shops == null)
                return NotFound($"No shop found for shopId = {string.Join(", ", shopIds)}.");

            Product product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Prices = _mapper.Map<List<Price>>(dto.PricesDtos),
                Shops = shops
            };

            _dbContext.Products.Add(product);

            return Ok(await _dbContext.SaveChangesAsync());
        }

        [HttpPost(nameof(AddDiscount))]
        public async Task<ActionResult> AddDiscount([FromBody] DiscountRequest dto)
        {
            if (dto == null || dto.ShopIds.Count == 0 || dto.ProductIds.Count == 0)
                return BadRequest("Invalid product data or shopsId.");

            List<Product> products = await _dbContext.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            List<Shop> shops = await _dbContext.Shops
                 .Where(s => dto.ShopIds.Contains(s.Id))
                .ToListAsync();

            if (products.Count == 0 || shops.Count == 0)
                return NotFound($"No shop or product found for shopId = {string.Join(", ", dto.ShopIds)} or productId = {string.Join(", ", dto.ProductIds)}.");

            Discount discount = _mapper.Map<Discount>(dto);

            _dbContext.Discounts.Add(discount);

            return Ok(await _dbContext.SaveChangesAsync());
        }
    }
}
