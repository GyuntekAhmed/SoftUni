namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using P02_FootballBetting.Data.Common;

    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerNameMaxLength)]
        public string Name { get; set; }

        public byte SquadNumber { get; set; }

        public int TeamId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public bool IsInjured { get; set; }
    }
}
