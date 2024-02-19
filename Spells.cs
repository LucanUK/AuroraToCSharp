using System.Xml.Serialization;

namespace AuroraToCSharp
{
    [XmlRoot(ElementName = "p")]
    public class SpellsP
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "b")]
        public SpellsB SpellsB { get; set; }
        [XmlElement(ElementName = "strong")]
        public SpellsStrong SpellsStrong { get; set; }
        [XmlElement(ElementName = "i")]
        public List<string> I { get; set; }
    }

    [XmlRoot(ElementName = "description")]
    public class SpellsDescription
    {
        [XmlElement(ElementName = "p")]
        public List<SpellsP> P { get; set; }
        [XmlElement(ElementName = "h5")]
        public string H5 { get; set; }
        [XmlElement(ElementName = "table")]
        public List<SpellsTable> Table { get; set; }
        [XmlElement(ElementName = "ul")]
        public SpellsUl SpellsUl { get; set; }
    }

    [XmlRoot(ElementName = "set")]
    public class SpellsSet
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "setters")]
    public class SpellsSetters
    {
        [XmlElement(ElementName = "set")]
        public List<SpellsSet> Set { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class SpellsElement
    {
        [XmlElement(ElementName = "supports")]
        public string Supports { get; set; }
        public string Description_Custom { get; set; }
      /* [XmlElement(ElementName = "description")]
        public Description Description { get; set; } */
        [XmlElement(ElementName = "setters")]
        public SpellsSetters SpellsSetters { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "b")]
    public class SpellsB
    {
        [XmlElement(ElementName = "i")]
        public string I { get; set; }
    }

    [XmlRoot(ElementName = "strong")]
    public class SpellsStrong
    {
        [XmlElement(ElementName = "em")]
        public string Em { get; set; }
    }

    [XmlRoot(ElementName = "tr")]
    public class SpellsTr
    {
        [XmlElement(ElementName = "td")]
        public List<string> Td { get; set; }
    }

    [XmlRoot(ElementName = "thead")]
    public class SpellsThead
    {
        [XmlElement(ElementName = "tr")]
        public SpellsTr SpellsTr { get; set; }
    }

    [XmlRoot(ElementName = "table")]
    public class SpellsTable
    {
        [XmlElement(ElementName = "thead")]
        public SpellsThead SpellsThead { get; set; }
        [XmlElement(ElementName = "tr")]
        public List<SpellsTr> Tr { get; set; }
    }

    [XmlRoot(ElementName = "ul")]
    public class SpellsUl
    {
        [XmlElement(ElementName = "li")]
        public List<SpellsLi> Li { get; set; }
    }

    [XmlRoot(ElementName = "li")]
    public class SpellsLi
    {
        [XmlElement(ElementName = "strong")]
        public string Strong { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class SpellsElements
    {
        [XmlElement(ElementName = "element")]
        public List<SpellsElement> Element { get; set; }
    }

}
