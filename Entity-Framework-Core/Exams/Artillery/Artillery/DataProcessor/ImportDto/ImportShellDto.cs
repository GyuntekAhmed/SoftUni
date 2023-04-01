namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Utilities;

    [XmlType("Shell")]
    public class ImportShellDto
    {
        [XmlElement("ShellWeight")]
        [Range(GlobalConstants.ShellWeightMinValue, GlobalConstants.ShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [MinLength(GlobalConstants.ShellCaliberMinValue)]
        [MaxLength(GlobalConstants.ShellCaliberMaxValue)]
        public string Caliber { get; set; } = null!;
    }
}
