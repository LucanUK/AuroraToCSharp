using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AuroraToCSharp
{
   [XmlRoot(ElementName = "p")]
   public class RacesP
   {
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
      [XmlText]
      public string Text { get; set; }
      [XmlElement(ElementName = "b")]
      public List<string> B { get; set; }
      [XmlElement(ElementName = "br")]
      public List<string> Br { get; set; }
      [XmlElement(ElementName = "span")]
      public List<RacesSpan> Span { get; set; }
   }

   [XmlRoot(ElementName = "span")]
   public class RacesSpan
   {
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
      [XmlText]
      public string Text { get; set; }
   }

   [XmlRoot(ElementName = "description")]
   public class RacesDescription
   {
      [XmlElement(ElementName = "p")]
      public List<RacesP> P { get; set; }
      [XmlElement(ElementName = "h4")]
      public List<string> H4 { get; set; }
      [XmlElement(ElementName = "h5")]
      public string H5 { get; set; }
      [XmlElement(ElementName = "table")]
      public RacesTable RacesTable { get; set; }
      [XmlElement(ElementName = "div")]
      public RacesDiv RacesDiv { get; set; }
   }

   [XmlRoot(ElementName = "sheet")]
   public class RacesSheet
   {
      [XmlAttribute(AttributeName = "display")]
      public string Display { get; set; }
      [XmlElement(ElementName = "description")]
      public string Description { get; set; }
      [XmlAttribute(AttributeName = "action")]
      public string Action { get; set; }
      [XmlAttribute(AttributeName = "usage")]
      public string Usage { get; set; }
      [XmlAttribute(AttributeName = "alt")]
      public string Alt { get; set; }
   }

   [XmlRoot(ElementName = "set")]
   public class RacesSet
   {
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlText]
      public string Text { get; set; }
      [XmlAttribute(AttributeName = "modifier")]
      public string Modifier { get; set; }
   }

   [XmlRoot(ElementName = "setters")]
   public class RacesSetters
   {
      [XmlElement(ElementName = "set")]
      public List<RacesSet> Set { get; set; }
   }

   [XmlRoot(ElementName = "stat")]
   public class RacesStat
   {
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "value")]
      public string Value { get; set; }
      [XmlAttribute(AttributeName = "requirements")]
      public string Requirements { get; set; }
      [XmlAttribute(AttributeName = "bonus")]
      public string Bonus { get; set; }
      [XmlAttribute(AttributeName = "level")]
      public string Level { get; set; }
      [XmlAttribute(AttributeName = "inline")]
      public string Inline { get; set; }
   }

   [XmlRoot(ElementName = "grant")]
   public class RacesGrant
   {
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "id")]
      public string Id { get; set; }
      [XmlAttribute(AttributeName = "requirements")]
      public string Requirements { get; set; }
   }

   [XmlRoot(ElementName = "select")]
   public class RacesSelect
   {
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "supports")]
      public string Supports { get; set; }
      [XmlAttribute(AttributeName = "optional")]
      public string Optional { get; set; }
   }

   [XmlRoot(ElementName = "rules")]
   public class RacesRules
   {
      [XmlElement(ElementName = "stat")]
      public List<RacesStat> Stat { get; set; }
      [XmlElement(ElementName = "grant")]
      public List<RacesGrant> Grant { get; set; }
      [XmlElement(ElementName = "select")]
      public RacesSelect RacesSelect { get; set; }
   }

   [XmlRoot(ElementName = "element")]
   public class RacesElement
   {
      public string Description_Custom { get; set; }
      /* [XmlElement(ElementName = "description")]
       public Description Description { get; set; }*/
      [XmlElement(ElementName = "sheet")]
      public RacesSheet RacesSheet { get; set; }
      [XmlElement(ElementName = "setters")]
      public RacesSetters RacesSetters { get; set; }
      [XmlElement(ElementName = "rules")]
      public RacesRules RacesRules { get; set; }
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "source")]
      public string Source { get; set; }
      [XmlAttribute(AttributeName = "id")]
      public string Id { get; set; }
      [XmlElement(ElementName = "supports")]
      public string Supports { get; set; }
   }

   [XmlRoot(ElementName = "tr")]
   public class RacesTr
   {
      [XmlElement(ElementName = "td")]
      public List<string> Td { get; set; }
   }

   [XmlRoot(ElementName = "thead")]
   public class RacesThead
   {
      [XmlElement(ElementName = "tr")]
      public RacesTr RacesTr { get; set; }
   }

   [XmlRoot(ElementName = "table")]
   public class RacesTable
   {
      [XmlElement(ElementName = "thead")]
      public RacesThead RacesThead { get; set; }
      [XmlElement(ElementName = "tr")]
      public List<RacesTr> Tr { get; set; }
   }

   [XmlRoot(ElementName = "div")]
   public class RacesDiv
   {
      [XmlAttribute(AttributeName = "element")]
      public string Element { get; set; }
   }

   [XmlRoot(ElementName = "elements")]
   public class RacesElements
   {
      [XmlElement(ElementName = "element")]
      public List<RacesElement> Element { get; set; }
   }

}