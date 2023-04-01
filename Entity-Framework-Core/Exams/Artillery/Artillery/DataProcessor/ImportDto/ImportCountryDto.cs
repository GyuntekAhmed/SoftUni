namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Utilities;

    [XmlType("Country")]
    public class ImportCountryDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MinLength(GlobalConstants.CountryNameMinLength)]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string CountryName { get; set; } = null!;

        [XmlElement("ArmySize")]
        [Required]
        [Range(GlobalConstants.CountryArmySizeMinValue,GlobalConstants.CountryArmySizeMaxValue)]
        public int ArmySize { get; set; }

    }
}
