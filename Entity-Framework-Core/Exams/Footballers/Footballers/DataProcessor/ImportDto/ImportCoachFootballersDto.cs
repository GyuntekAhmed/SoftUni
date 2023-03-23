namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Data.Models.Enums;

    [XmlType("Footballer")]
    public class ImportCoachFootballersDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("ContractStartDate")]
        public DateTime ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public DateTime ContractEndDate { get; set; }

        [Required]
        [XmlElement("PositionType")]
        [Range(0, 3)]
        public PositionType PositionType { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public BestSkillType BestSkillType { get; set; }
    }
}
