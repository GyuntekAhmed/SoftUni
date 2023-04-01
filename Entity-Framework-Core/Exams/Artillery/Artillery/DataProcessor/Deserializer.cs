namespace Artillery.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Newtonsoft.Json;

    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Utilities;
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCountryDto[] countryDtos = xmlHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            ICollection<Country> validCountries = new HashSet<Country>();

            foreach (ImportCountryDto countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };

                validCountries.Add(country);

                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportManufacturerDto[] manufacturerDtos = xmlHelper.Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");

            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();

            foreach (ImportManufacturerDto manufacturerDto in manufacturerDtos)
            {
                var uniqueManufacturer = validManufacturers.FirstOrDefault
                    (m => m.ManufacturerName== manufacturerDto.ManufacturerName);

                if (!IsValid(manufacturerDto) || uniqueManufacturer != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                validManufacturers.Add(manufacturer);
                var manufacturerCountry = manufacturer.Founded.Split(", ").ToArray();
                var last = manufacturerCountry.Skip(Math.Max(0, manufacturerCountry.Count() - 2)).ToArray();
                sb.AppendLine(string.Format
                    (SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", last)));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportShellDto[] shellDtos = xmlHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            ICollection<Shell> validShells = new HashSet<Shell>();

            foreach (ImportShellDto shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                validShells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };

            ICollection<Gun> validGuns = new HashSet<Gun>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto) || !validGunTypes.Contains(gunDto.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    BarrelLength = gunDto.BarrelLength,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gunDto.GunType),
                    GunWeight = gunDto.GunWeight,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    ShellId = gunDto.ShellId,
                };

                foreach (var countryGunDto in gunDto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = countryGunDto.Id,
                        Gun = gun
                    });
                }

                validGuns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gunDto.GunType, gunDto.GunWeight, gunDto.BarrelLength));
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}