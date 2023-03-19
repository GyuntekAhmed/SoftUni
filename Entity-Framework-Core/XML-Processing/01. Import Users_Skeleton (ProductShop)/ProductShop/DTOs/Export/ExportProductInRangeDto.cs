namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType("Product")]
    public class ExportProductInRangeDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; } = null!;
    }
}
