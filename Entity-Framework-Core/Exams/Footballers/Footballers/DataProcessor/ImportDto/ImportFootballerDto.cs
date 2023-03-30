namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Utilities;

    [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.FootballerNameMinLength)]
        [MaxLength(GlobalConstants.FootballerNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; } = null!;

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; } = null!;

        [XmlElement("PositionType")]
        [Required]
        [Range(0, 3)]
        public int PositionType { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [Range(0, 4)]
        public int BestSkillType { get; set; }
    }
}
