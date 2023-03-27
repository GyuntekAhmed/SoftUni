namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Data.Models;
    using ImportDto;
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlHelper xmlHelper = new XmlHelper();

            ImportDespatcherDto[] despatcherDtos = xmlHelper
                .Deserialize<ImportDespatcherDto[]>(xmlString, "Trucks");

            ICollection<Despatcher> despatchers = new HashSet<Despatcher>();
            ICollection<Truck> trucks = new HashSet<Truck>();

            foreach (ImportDespatcherDto despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (ImportTruckDto[] truckDto in despatcherDto.TruckDtos)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                }
                //Supplier supplier = mapper.Map<Supplier>(supplierDto);

                //suppliers.Add(supplier);
            }

            //context.Suppliers.AddRange(suppliers);
            //context.SaveChanges();

            //return $"Successfully imported {suppliers.Count}";
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}