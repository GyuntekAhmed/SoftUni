namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using P02_FootballBetting.Data.Common;

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string Name { get; set; }
    }
}
