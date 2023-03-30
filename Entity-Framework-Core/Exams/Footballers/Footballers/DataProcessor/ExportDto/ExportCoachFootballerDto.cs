namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ExportCoachFootballerDto
    {
        [XmlElement("Name")] 
        public string Name { get; set; } = null!;

        [XmlElement("Position")] 
        public string Position { get; set; } = null!;
    }
}