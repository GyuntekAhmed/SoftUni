namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using Enums;

    public class Resource
    {
        [Key]
        public int RecourceId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.RecourceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.RecourceUrlMaxLength)]
        public string Url { get; set; } = null!;

        [Required]
        public RecourceType RecourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;
    }
}
