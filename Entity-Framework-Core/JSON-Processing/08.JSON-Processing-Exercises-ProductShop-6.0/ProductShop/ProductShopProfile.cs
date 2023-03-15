namespace ProductShop
{
    using AutoMapper;

    using DTOs.Import;
    using Models;
    using ProductShop.DTOs.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.Name,
                            opt => opt.MapFrom(
                                s => s.Name))
                .ForMember(d => d.Price,
                            opt => opt.MapFrom(
                                s => s.Price))
                .ForMember(d => d.SellerName,
                            opt => opt.MapFrom(
                                s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
