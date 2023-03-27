namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Utilities;

    [XmlType]
    public class ImportDespatcherDto
    {
        [Required]
        [XmlElement]
        [MinLength(GlobalConstants.DespatcherNameMinLength)]
        [MaxLength(GlobalConstants.DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement]
        public string Position { get; set; } = null!;

        [XmlArray]
        public virtual ICollection<ImportTruckDto[]> TruckDtos { get; set; } = null!;
    }
}
