﻿namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class TotalSalesByCustomerDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public string SpentMoney { get; set; }
    }
}
