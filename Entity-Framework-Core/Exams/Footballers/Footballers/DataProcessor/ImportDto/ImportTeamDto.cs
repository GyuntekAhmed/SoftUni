namespace Footballers.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class ImportTeamDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(GlobalConstants.TeamNameMinLength)]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        [RegularExpression(GlobalConstants.TeamNameRegex)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(GlobalConstants.TeamNationalityMinLength)]
        [MaxLength(GlobalConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; } = null!;
    }
}
