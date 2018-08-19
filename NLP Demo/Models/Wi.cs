using System.Xml.Serialization;

namespace NLP_Demo.Models
{
    public class Wi
    {
        [XmlAttribute(AttributeName = "num")]
        public string Num { get; set; }
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    
    public class WiCollection
    {
        [XmlArray("parent")]
        [XmlArrayItem("wi", typeof(Wi))]
        public Wi[] Wi { get; set; }
    }
}
