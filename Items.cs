using System.Xml.Serialization;

namespace AuroraToCSharp
{

    [XmlRoot(ElementName = "description")]
    public class ItemsDescription
    {
        [XmlElement(ElementName = "p")]
        public string P { get; set; }
        [XmlElement(ElementName = "div")]
        public ItemsDiv ItemsDiv { get; set; }
    }

    [XmlRoot(ElementName = "set")]
    public class ItemsSet
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "currency")]
        public string Currency { get; set; }
        [XmlAttribute(AttributeName = "lb")]
        public string Lb { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "setters")]
    public class ItemsSetters
    {
        [XmlElement(ElementName = "set")]
        public List<ItemsSet> Set { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class ItemsElement
    {
        [XmlElement(ElementName = "supports")]
        public string Supports { get; set; }
        public string Description_Custom { get; set; }
        /*[XmlElement(ElementName = "description")]
        public Description Description { get; set; }*/
        [XmlElement(ElementName = "setters")]
        public ItemsSetters ItemsSetters { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "div")]
    public class ItemsDiv
    {
        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class ItemsElements
    {
        [XmlElement(ElementName = "element")]
        public List<ItemsElement> Element { get; set; }
    }

}
