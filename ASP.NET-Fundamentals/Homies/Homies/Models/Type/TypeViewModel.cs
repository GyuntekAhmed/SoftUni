namespace Homies.Models.Type
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.TypeValidations;

    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
