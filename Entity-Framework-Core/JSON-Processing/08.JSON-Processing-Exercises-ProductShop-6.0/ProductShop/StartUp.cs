namespace ProductShop
{
    using Newtonsoft.Json;
    using AutoMapper;

    using Data;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = mapperConfiguration.CreateMapper();

            ProductShopContext dbContext = new ProductShopContext();
            string inputJson = File.ReadAllText("../../../Datasets/users.json");

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine("Database was successfully created!");

            string output = ImportUsers(dbContext, inputJson);

            Console.WriteLine(output);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}