namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.TypeValidations;

    public class Type
    {
        public Type()
        {
            this.Events = new List<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Event> Events { get; set; }
    }
}
