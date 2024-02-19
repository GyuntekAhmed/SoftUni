using System.ComponentModel.DataAnnotations;
using AspNetCoreTemplate.Data.Common.Validation;

namespace AspNetCoreTemplate.Data.Models
{

    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(ApplicationValidationConstants.UserNameMaxLength)]
        public string UserName { get; set; } = null!;
    }
}
