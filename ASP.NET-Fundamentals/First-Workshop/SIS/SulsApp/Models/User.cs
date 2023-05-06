using System.ComponentModel.DataAnnotations;

namespace SulsApp.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
