namespace Artillery.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Utilities;

    public class ImportGunDto
    {
        [JsonProperty("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Range(GlobalConstants.GunWeightMinLength, GlobalConstants.GunWeightMaxLength)]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        [Range(GlobalConstants.GunBarrelMinValue, GlobalConstants.GunBarrelMaxValue)]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [JsonProperty("Range")]
        [Range(GlobalConstants.GunRangeMinValue, GlobalConstants.GunRangeMaxValue)]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        [Required]
        public string GunType { get; set; } = null!;

        [JsonProperty("ShellId")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public virtual ImportCountryGunDto[] Countries { get; set; } = null!;
    }
}
