namespace CarDealer
{
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    using Utilities;
    using Data;
    using Models;
    using DTOs.Import;
    using DTOs.Export;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            string inputXml =
                File.ReadAllText("../../../Datasets/customers.xml");

            string output = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDto[] supplierDtos = xmlHelper
                .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos =
                xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDto partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    // Missing or wrong supplier id
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos =
                xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (ImportCarDto carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) ||
                    string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos =
                xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();
            foreach (ImportCustomerDto customerDto in customerDtos)
            {
                if (string.IsNullOrEmpty(customerDto.Name) ||
                    string.IsNullOrEmpty(customerDto.BirthDate))
                {
                    continue;
                }

                Customer customer = mapper.Map<Customer>(customerDto);
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSaleDto[] saleDtos =
                xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            // Optimization
            ICollection<int> dbCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (ImportSaleDto saleDto in saleDtos)
            {
                if (!saleDto.CarId.HasValue ||
                    dbCarIds.All(id => id != saleDto.CarId.Value))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarDto[]>(cars, "cars");
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportBmwCarDto[] bmwCars = context.Cars
                .Where(c => c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(bmwCars, "cars");
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            LocalSuppliersDto[] localSuppliersDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSuppliersDto()
                {
                    Name = s.Name,
                    Id = s.Id,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            return xmlHelper.Serialize<LocalSuppliersDto[]>(localSuppliersDtos, "suppliers");
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithPartsDto[] carsWithParts = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carsWithParts, "cars");
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            TotalSalesByCustomerDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new TotalSalesByCustomerDto()
                {
                    FullName = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return xmlHelper.Serialize<TotalSalesByCustomerDto[]>(totalSalesDtos, "customers");
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            SalesWithAppliedDiscountDto[] salesDtos = context
                .Sales
                .Select(s => new SalesWithAppliedDiscountDto()
                {
                    SingleCar = new SingleCar()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            return xmlHelper.Serialize<SalesWithAppliedDiscountDto[]>(salesDtos, "sales");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}