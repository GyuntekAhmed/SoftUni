namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using P02_FootballBetting.Data.Common;

    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TownNameMaxLength)]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
