namespace Artillery.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ShellCaliberMaxValue)]
        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
