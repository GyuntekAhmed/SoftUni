namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Utilities;

    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [MinLength(GlobalConstants.ManufacturerNameMinLength)]
        [MaxLength(GlobalConstants.ManufacturerNameMaxLength)]
        public string ManufacturerName { get; set; } = null!;

        [XmlElement("Founded")]
        [Required]
        [MinLength(GlobalConstants.ManufacturerFoundedMinValue)]
        [MaxLength(GlobalConstants.ManufacturerFoundedMaxValue)]
        public string Founded { get; set; } = null!;
    }
}
