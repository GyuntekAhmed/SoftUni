namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    using Common;

    [JsonObject]
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        [MinLength(GlobalConstants.UserLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
