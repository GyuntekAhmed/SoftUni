namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType]
    public class ImportTruckDto
    {
        [Required]
        [XmlElement]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [XmlElement]
        public string VinNumber { get; set; } = null!;

        [XmlElement]
        public int TankCapacity { get; set; }

        [XmlElement]
        public int CargoCapacity { get; set; }

        [XmlElement]
        public int CategoryType { get; set; }

        [XmlElement]
        public int MakeType { get; set; }
    }
}
