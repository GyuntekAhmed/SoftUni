using System.ComponentModel.DataAnnotations;

namespace SulsApp.Models
{
    public class Problem
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        public int Points { get; set; }
    }
}
