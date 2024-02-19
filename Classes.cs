using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AuroraToCSharp         
{
   [XmlRoot(ElementName = "p")]
   public class ClassesP
   {
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
      [XmlText]
      public string Text { get; set; }
      [XmlElement(ElementName = "i")]
      public List<string> I { get; set; }
      [XmlElement(ElementName = "strong")]
      public ClassesStrong ClassesStrong { get; set; }
      [XmlElement(ElementName = "em")]
      public string Em { get; set; }
   }

   [XmlRoot(ElementName = "li")]
   public class ClassesLi
   {
      [XmlElement(ElementName = "strong")]
      public string Strong { get; set; }
   }

   [XmlRoot(ElementName = "ul")]
   public class ClassesUl
   {
      [XmlElement(ElementName = "li")]
      public List<ClassesLi> Li { get; set; }
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
   }

   [XmlRoot(ElementName = "h5")]
   public class ClassesH5
   {
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
      [XmlText]
      public string Text { get; set; }
   }

   [XmlRoot(ElementName = "td")]
   public class ClassesTd
   {
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
      [XmlText]
      public string Text { get; set; }
   }

   [XmlRoot(ElementName = "tr")]
   public class ClassesTr
   {
      [XmlElement(ElementName = "td")]
      public List<ClassesTd> Td { get; set; }
   }

   [XmlRoot(ElementName = "thead")]
   public class ClassesThead
   {
      [XmlElement(ElementName = "tr")]
      public ClassesTr ClassesTr { get; set; }
   }

   [XmlRoot(ElementName = "table")]
   public class ClassesTable
   {
      [XmlElement(ElementName = "thead")]
      public ClassesThead ClassesThead { get; set; }
      [XmlElement(ElementName = "tr")]
      public List<ClassesTr> Tr { get; set; }
      [XmlAttribute(AttributeName = "class")]
      public string Class { get; set; }
   }

   [XmlRoot(ElementName = "div")]
   public class ClassesDiv
   {
      [XmlAttribute(AttributeName = "element")]
      public string Element { get; set; }
   }

   [XmlRoot(ElementName = "description")]
   public class ClassesDescription
   {
      [XmlElement(ElementName = "p")]
      public List<ClassesP> P { get; set; }
      [XmlElement(ElementName = "h4")]
      public List<string> H4 { get; set; }
      [XmlElement(ElementName = "h3")]
      public string H3 { get; set; }
      [XmlElement(ElementName = "ul")]
      public List<ClassesUl> Ul { get; set; }
      [XmlElement(ElementName = "h5")]
      public ClassesH5 ClassesH5 { get; set; }
      [XmlElement(ElementName = "table")]
      public ClassesTable ClassesTable { get; set; }
      [XmlElement(ElementName = "div")]
      public List<ClassesDiv> Div { get; set; }
      [XmlElement(ElementName = "center")]
      public ClassesCenter ClassesCenter { get; set; }
   }

   [XmlRoot(ElementName = "sheet")]
   public class ClassesSheet
   {
      [XmlElement(ElementName = "description")]
      public string Description { get; set; }
      [XmlAttribute(AttributeName = "display")]
      public string Display { get; set; }
      [XmlAttribute(AttributeName = "usage")]
      public string Usage { get; set; }
      [XmlAttribute(AttributeName = "action")]
      public string Action { get; set; }
   }

   [XmlRoot(ElementName = "set")]
   public class ClassesSet
   {
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlText]
      public string Text { get; set; }
   }

   [XmlRoot(ElementName = "setters")]
   public class ClassesSetters
   {
      [XmlElement(ElementName = "set")]
      public List<ClassesSet> Set { get; set; }
   }

   [XmlRoot(ElementName = "grant")]
   public class ClassesGrant
   {
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "id")]
      public string Id { get; set; }
      [XmlAttribute(AttributeName = "requirements")]
      public string Requirements { get; set; }
      [XmlAttribute(AttributeName = "level")]
      public string Level { get; set; }
      [XmlAttribute(AttributeName = "spellcasting")]
      public string Spellcasting { get; set; }
   }

   [XmlRoot(ElementName = "select")]
   public class ClassesSelect
   {
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "supports")]
      public string Supports { get; set; }
      [XmlAttribute(AttributeName = "number")]
      public string Number { get; set; }
      [XmlAttribute(AttributeName = "requirements")]
      public string Requirements { get; set; }
      [XmlAttribute(AttributeName = "level")]
      public string Level { get; set; }
      [XmlAttribute(AttributeName = "spellcasting")]
      public string Spellcasting { get; set; }
      [XmlAttribute(AttributeName = "default")]
      public string Default { get; set; }
      [XmlAttribute(AttributeName = "default-behaviour")]
      public string Defaultbehaviour { get; set; }
   }

   [XmlRoot(ElementName = "rules")]
   public class ClassesRules
   {
      [XmlElement(ElementName = "grant")]
      public List<ClassesGrant> Grant { get; set; }
      [XmlElement(ElementName = "select")]
      public List<ClassesSelect> Select { get; set; }
      [XmlElement(ElementName = "stat")]
      public List<ClassesStat> Stat { get; set; }
   }

   [XmlRoot(ElementName = "multiclass")]
   public class ClassesMulticlass
   {
      [XmlElement(ElementName = "prerequisite")]
      public string Prerequisite { get; set; }
      [XmlElement(ElementName = "requirements")]
      public string Requirements { get; set; }
      [XmlElement(ElementName = "setters")]
      public ClassesSetters ClassesSetters { get; set; }
      [XmlElement(ElementName = "rules")]
      public ClassesRules ClassesRules { get; set; }
      [XmlAttribute(AttributeName = "id")]
      public string Id { get; set; }
   }

   [XmlRoot(ElementName = "element")]
   public class ClassesElement
   {
      public string Description_Custom { get; set; }
      /*[XmlElement(ElementName = "description")]
      public Description Description { get; set; }*/
      [XmlElement(ElementName = "sheet")]
      public ClassesSheet ClassesSheet { get; set; }
      [XmlElement(ElementName = "setters")]
      public ClassesSetters ClassesSetters { get; set; }
      [XmlElement(ElementName = "rules")]
      public ClassesRules ClassesRules { get; set; }
      [XmlElement(ElementName = "multiclass")]
      public ClassesMulticlass ClassesMulticlass { get; set; }
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "type")]
      public string Type { get; set; }
      [XmlAttribute(AttributeName = "source")]
      public string Source { get; set; }
      [XmlAttribute(AttributeName = "id")]
      public string Id { get; set; }
      [XmlElement(ElementName = "spellcasting")]
      public ClassesSpellcasting ClassesSpellcasting { get; set; }
      [XmlElement(ElementName = "compendium")]
      public ClassesCompendium ClassesCompendium { get; set; }
      [XmlElement(ElementName = "supports")]
      public string Supports { get; set; }
   }

   [XmlRoot(ElementName = "center")]
   public class ClassesCenter
   {
      [XmlElement(ElementName = "p")]
      public List<ClassesP> P { get; set; }
   }

   [XmlRoot(ElementName = "spellcasting")]
   public class ClassesSpellcasting
   {
      [XmlElement(ElementName = "list")]
      public string List { get; set; }
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "ability")]
      public string Ability { get; set; }
      [XmlAttribute(AttributeName = "prepare")]
      public string Prepare { get; set; }
   }

   [XmlRoot(ElementName = "stat")]
   public class ClassesStat
   {
      [XmlAttribute(AttributeName = "name")]
      public string Name { get; set; }
      [XmlAttribute(AttributeName = "value")]
      public string Value { get; set; }
      [XmlAttribute(AttributeName = "level")]
      public string Level { get; set; }
      [XmlAttribute(AttributeName = "bonus")]
      public string Bonus { get; set; }
   }

   [XmlRoot(ElementName = "compendium")]
   public class ClassesCompendium
   {
      [XmlAttribute(AttributeName = "display")]
      public string Display { get; set; }
   }

   [XmlRoot(ElementName = "strong")]
   public class ClassesStrong
   {
      [XmlElement(ElementName = "em")]
      public string Em { get; set; }
   }

   [XmlRoot(ElementName = "elements")]
   public class ClassesElements
   {
      [XmlElement(ElementName = "element")]
      public List<ClassesElement> Element { get; set; }
   }

}