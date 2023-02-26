using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.TeamLogoUrlMaxLength)]
        public string LogoUrl { get; set; }

        [MaxLength(GlobalConstants.TeamInitialMaxLength)]
        public string Initial { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
    }
}