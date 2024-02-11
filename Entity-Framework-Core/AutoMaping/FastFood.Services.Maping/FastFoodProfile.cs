namespace FastFood.Services.Mapping
{
    using AutoMapper;

    using Web.ViewModels.Items;
    using Web.ViewModels.Categories;
    using Models;
    using Web.ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(s => s.Name));

            // Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(x => x.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(s => s.Name));

            // Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId,
                    y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName,
                    y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModel>()
                .ForMember(x => x.Category,
                    y => y.MapFrom(s => s.Category.Name));
        }
    }
}
