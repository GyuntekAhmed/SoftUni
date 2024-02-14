namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;

    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using Models;
    using DTOs.Export;
    using DTOs.Import;


    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //var inputJson =
            //    File.ReadAllText(@"../../../Datasets/categories-products.json");

            var result = GetSoldProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                var user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            // Here we have all valid users ready for the Database
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            var products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var catProdDtos =
                JsonConvert
                    .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();

            foreach (var cpDto in catProdDtos)
            {
                if (!context.Categories.Any(c => c.Id == cpDto.CategoryId) ||
                    !context.Products.Any(p => p.Id == cpDto.ProductId))
                {
                    continue;
                }

                CategoryProduct categoryProduct =
                    mapper.Map<CategoryProduct>(cpDto);

                validEntries.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();

            return $"Successfully imported {validEntries.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            //var products = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //    {
            //        name = p.Name,
            //        price = p.Price,
            //        seller = p.Seller.FirstName + " " + p.Seller.LastName,

            //    })
            //    .AsNoTracking()
            //    .ToArray();

            IMapper mapper = CreateMapper();

            var productDtos = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var contractResolver = ConfigureCamelCaseNaming();

            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(usersWithSoldProducts,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}