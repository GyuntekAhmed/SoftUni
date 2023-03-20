﻿namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class LocalSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
