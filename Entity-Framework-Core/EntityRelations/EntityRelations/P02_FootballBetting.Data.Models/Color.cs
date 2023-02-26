namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using P02_FootballBetting.Data.Common;

    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; }
    }
}
