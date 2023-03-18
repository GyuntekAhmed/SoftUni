namespace ProductShop
{
    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {

        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
    }
}