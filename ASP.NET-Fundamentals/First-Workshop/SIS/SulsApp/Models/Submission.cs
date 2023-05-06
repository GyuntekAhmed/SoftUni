using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SulsApp.Models
{
    public class Submission
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(800)]
        public string Code { get; set; } = null!;

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Problem))]
        public string ProblemId { get; set; } = null!;
        public virtual Problem Problem { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
