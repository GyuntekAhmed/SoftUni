namespace ProductShop
{
    using AutoMapper;

    using DTOs.Import;
    using DTOs.Export;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>()
                .ForMember(d => d.Age,
                opt => opt.MapFrom(s => s.Age!.Value));

            //this.CreateMap<ImportProductDto, Product>()
            //    .ForMember(d => d.BuyerId,
            //    opt => opt.MapFrom(s => s.BuyerId!.Value));

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>();
        }
    }
}
