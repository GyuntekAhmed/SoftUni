namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Color
{
    public Color()
    {
        this.PrimaryKitTeams = new HashSet<Team>();
        this.SecondaryKitTeams = new HashSet<Team>();
    }

    [Key]
    public int ColorId { get; set; }

    [MaxLength(GlobalConstants.ColorNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Team> PrimaryKitTeams { get; set; }

    public virtual ICollection<Team> SecondaryKitTeams { get; set; }
}