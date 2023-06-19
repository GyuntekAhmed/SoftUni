namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.EventValidations;
    using Homies.Models.Type;

    public class EventFormViewModel
    {
        public EventFormViewModel()
        {
            this.Types = new List<TypeViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Display(Name = "Type of event")]
        public int TypeId { get; set; }

        public string OrganaizerId { get; set; } = null!;

        public List<TypeViewModel> Types { get; set; }
    }
}
