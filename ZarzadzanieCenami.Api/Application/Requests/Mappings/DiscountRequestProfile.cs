namespace ZarzadzanieCenami.Api.Application.Requests.Mappings
{
    public class DiscountRequestProfile : AutoMapper.Profile
    {
        public DiscountRequestProfile()
        {
            CreateMap<DiscountRequest, Domain.Entities.Discount>().ReverseMap();
        }
    }
}
