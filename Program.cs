using System.Xml.Serialization;
/*using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net.Http.Headers;
using System.Linq;
using System.Security.Claims;*/

internal class Program
{
    private static void Main(string[] args)
    {
        
        string sourceFolderPath = "C:\\Users\\Lucan\\source\\repos\\AuroraToCSharp\\XMLImport";
        string spellsFolderPath = sourceFolderPath + "\\spells";
        string itemsFolderPath = sourceFolderPath + "\\items";
        string racesFolderPath = sourceFolderPath + "\\races";
        string classesFolderPath = sourceFolderPath + "\\classes";

        List<Spells.Elements> SpellsList = new List<Spells.Elements>();
        List<Items.Elements> ItemsList = new List<Items.Elements>();
        List<Races.Elements> RacesList = new List<Races.Elements>();
        List<Classes.Elements> ClassesList = new List<Classes.Elements>();
        static void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            if (e.ObjectBeingDeserialized is Races.Element raceelement)
            {
                if (e.Element.Name == "description")
                {
                    raceelement.Description_Custom = e.Element.InnerXml;
                    return;
                }
            }
            if (e.ObjectBeingDeserialized is Classes.Element classelement)
            {
                if (e.Element.Name == "description")
                {
                    classelement.Description_Custom = e.Element.InnerXml;
                    return;
                }
            }
            if (e.ObjectBeingDeserialized is Items.Element itemelement)
            {
                if (e.Element.Name == "description")
                {
                    itemelement.Description_Custom = e.Element.InnerXml;
                    return;
                }
            }
            if (e.ObjectBeingDeserialized is Spells.Element spellelement)
            {
                if (e.Element.Name == "description")
                {
                    spellelement.Description_Custom = e.Element.InnerXml;
                    return;
                }
            }
        }
        if (Directory.Exists(spellsFolderPath))
        {
            DirectoryInfo dirSource = new DirectoryInfo(spellsFolderPath);
            var SpellsXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in SpellsXMLFiles)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Spells.Elements));
                    serializer.UnknownElement += Serializer_UnknownElement;
                    using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                    {
                        Spells.Elements result = serializer.Deserialize(reader) as Spells.Elements;
                        SpellsList.Add(result);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        if (Directory.Exists(itemsFolderPath))
        {
            DirectoryInfo dirSource = new DirectoryInfo(itemsFolderPath);
            var ItemXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in ItemXMLFiles)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Items.Elements));
                    serializer.UnknownElement += Serializer_UnknownElement;
                    using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                    {
                        Items.Elements result = serializer.Deserialize(reader) as Items.Elements;
                        ItemsList.Add(result);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        if (Directory.Exists(racesFolderPath))
        {
            DirectoryInfo dirSource = new DirectoryInfo(racesFolderPath);
            var AllXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in AllXMLFiles)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Races.Elements));
                    serializer.UnknownElement += Serializer_UnknownElement;
                    using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                    {
                        Races.Elements result = serializer.Deserialize(reader) as Races.Elements;
                        RacesList.Add(result);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        if (Directory.Exists(classesFolderPath))
        {
            DirectoryInfo dirSource = new DirectoryInfo(classesFolderPath);
            var AllXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in AllXMLFiles)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Classes.Elements));
                    serializer.UnknownElement += Serializer_UnknownElement;
                    using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                    {
                        Classes.Elements result = serializer.Deserialize(reader) as Classes.Elements;
                        ClassesList.Add(result);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


        string SearchRace = "Elf";
        string SearchClass = "Druid";
        string SearchSpell = "Detect Magic";
        string SearchWeapon = "Rapier";
        string SearchArmour = "Ring Mail";
        string SearchItem = "Bag Of Holding";
        string SearchSpellLevel = "5";

        Races.Element RaceCurrent = FindRace(RacesList, SearchRace);
        Classes.Element ClassCurrent = FindClass(ClassesList, SearchClass);
        Spells.Element SpellCurrent = FindSpell(SpellsList, SearchSpell);
        Items.Element WeaponCurrent = FindWeapon(ItemsList, SearchWeapon);
        Items.Element ArmourCurrent = FindArmour(ItemsList, SearchArmour);
        Items.Element ItemCurrent = FindItem(ItemsList, SearchItem);
        List<Spells.Element?> SpellClassCurrent = FindSpellByClass(SpellsList, SearchClass);
        List<Spells.Element?> SpellClassLevelCurrent = FindSpellByClassBySpellLevel(SpellsList, SearchClass, SearchSpellLevel);
        
        int test = 1;

        static Races.Element? FindRace(List<Races.Elements> RacesList, string SearchRace)
        {


            var RacesListResult = RacesList.SelectMany(c => c.Element).Where(cr => cr.Type == "Race");

            foreach (var Race in RacesListResult.Where(Races => Races.Name == SearchRace)
            )
            {

                return Race;
            }
            return null;
        }
        static Classes.Element? FindClass(List<Classes.Elements> ClassesList, string SearchClass)
        {


            var ClassListResult = ClassesList.SelectMany(c => c.Element).Where(cr => cr.Type == "Class");

            foreach (var Class in ClassListResult.Where(Classes => Classes.Name == SearchClass)
            )
            {

                return Class;
            }
            return null;
        }
        static Spells.Element? FindSpell(List<Spells.Elements> SpellsList, string SearchSpell)
        {


            var SpellsListResult = SpellsList.SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Spell in SpellsListResult.Where(Spells => Spells.Name == SearchSpell)
            )
            {

                return Spell;
            }
            return null;
        }
        static Items.Element? FindWeapon(List<Items.Elements> ItemsList, string SearchWeapon)
        {


            Items.Elements? WeaponsListResult = ItemsList[6];
            //var WeaponsListResult = ItemsListResult.  SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Weapon in WeaponsListResult.Element.Where(Weapons => Weapons.Name == SearchWeapon)
            )
            {
                return Weapon;
            }
            return null;
        }
        static Items.Element? FindArmour(List<Items.Elements> ItemsList, string SearchArmour)
        {


            Items.Elements? ArmourListResult = ItemsList[0];
            //var WeaponsListResult = ItemsListResult.  SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Armour in ArmourListResult.Element.Where(Armours => Armours.Name == SearchArmour)
            )
            {
                return Armour;
            }
            return null;
        }
        static Items.Element? FindItem(List<Items.Elements> ItemsList, string SearchItem)
        {


            var ItemsListResult = ItemsList.SelectMany(c => c.Element).Where(cr => cr.Type == "Item");

            //var WeaponsListResult = ItemsListResult.  SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Item in ItemsListResult.Where(Items => Items.Name == SearchItem)
            )
            {
                return Item;
            }
            return null;
        }
        static List<Spells.Element?> FindSpellByClass(List<Spells.Elements> SpellsList, string SearchClass)
        {


            var SpellsListResult = SpellsList.SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");
            var ClassSpellsResult = SpellsListResult.Where(Spells => Spells.Supports.Contains(SearchClass));
            return ClassSpellsResult.ToList();
            int test = 1;
            return null;

        }
        static List<Spells.Element?> FindSpellByClassBySpellLevel(List<Spells.Elements> SpellsList, string SearchClass, string SearchSpellLevel)
        {
            
            var ClassSpellsList = FindSpellByClass(SpellsList, SearchClass);
            var ClassSpellsResult = ClassSpellsList.Where(Spells => Spells.Setters.Set[1].Text == SearchSpellLevel);
            return ClassSpellsResult.ToList();
            int test = 1;
            return null;

        }
        
    }
}

namespace Items
{

    [XmlRoot(ElementName = "description")]
    public class Description
    {
        [XmlElement(ElementName = "p")]
        public string P { get; set; }
        [XmlElement(ElementName = "div")]
        public Div Div { get; set; }
    }

    [XmlRoot(ElementName = "set")]
    public class Set
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
    public class Setters
    {
        [XmlElement(ElementName = "set")]
        public List<Set> Set { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class Element
    {
        [XmlElement(ElementName = "supports")]
        public string Supports { get; set; }
        public string Description_Custom { get; set; }
        /*[XmlElement(ElementName = "description")]
        public Description Description { get; set; }*/
        [XmlElement(ElementName = "setters")]
        public Setters Setters { get; set; }
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
    public class Div
    {
        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class Elements
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }

}
namespace Spells
{
    [XmlRoot(ElementName = "p")]
    public class P
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "b")]
        public B B { get; set; }
        [XmlElement(ElementName = "strong")]
        public Strong Strong { get; set; }
        [XmlElement(ElementName = "i")]
        public List<string> I { get; set; }
    }

    [XmlRoot(ElementName = "description")]
    public class Description
    {
        [XmlElement(ElementName = "p")]
        public List<P> P { get; set; }
        [XmlElement(ElementName = "h5")]
        public string H5 { get; set; }
        [XmlElement(ElementName = "table")]
        public List<Table> Table { get; set; }
        [XmlElement(ElementName = "ul")]
        public Ul Ul { get; set; }
    }

    [XmlRoot(ElementName = "set")]
    public class Set
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "setters")]
    public class Setters
    {
        [XmlElement(ElementName = "set")]
        public List<Set> Set { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class Element
    {
        [XmlElement(ElementName = "supports")]
        public string Supports { get; set; }
        public string Description_Custom { get; set; }
      /* [XmlElement(ElementName = "description")]
        public Description Description { get; set; } */
        [XmlElement(ElementName = "setters")]
        public Setters Setters { get; set; }
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
    public class B
    {
        [XmlElement(ElementName = "i")]
        public string I { get; set; }
    }

    [XmlRoot(ElementName = "strong")]
    public class Strong
    {
        [XmlElement(ElementName = "em")]
        public string Em { get; set; }
    }

    [XmlRoot(ElementName = "tr")]
    public class Tr
    {
        [XmlElement(ElementName = "td")]
        public List<string> Td { get; set; }
    }

    [XmlRoot(ElementName = "thead")]
    public class Thead
    {
        [XmlElement(ElementName = "tr")]
        public Tr Tr { get; set; }
    }

    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlElement(ElementName = "thead")]
        public Thead Thead { get; set; }
        [XmlElement(ElementName = "tr")]
        public List<Tr> Tr { get; set; }
    }

    [XmlRoot(ElementName = "ul")]
    public class Ul
    {
        [XmlElement(ElementName = "li")]
        public List<Li> Li { get; set; }
    }

    [XmlRoot(ElementName = "li")]
    public class Li
    {
        [XmlElement(ElementName = "strong")]
        public string Strong { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class Elements
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }

}
namespace Races
{
    [XmlRoot(ElementName = "p")]
    public class P
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
        public List<Span> Span { get; set; }
    }

    [XmlRoot(ElementName = "span")]
    public class Span
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "description")]
    public class Description
    {
        [XmlElement(ElementName = "p")]
        public List<P> P { get; set; }
        [XmlElement(ElementName = "h4")]
        public List<string> H4 { get; set; }
        [XmlElement(ElementName = "h5")]
        public string H5 { get; set; }
        [XmlElement(ElementName = "table")]
        public Table Table { get; set; }
        [XmlElement(ElementName = "div")]
        public Div Div { get; set; }
    }

    [XmlRoot(ElementName = "sheet")]
    public class Sheet
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
    public class Set
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
    public class Setters
    {
        [XmlElement(ElementName = "set")]
        public List<Set> Set { get; set; }
    }

    [XmlRoot(ElementName = "stat")]
    public class Stat
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
    public class Grant
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "requirements")]
        public string Requirements { get; set; }
    }

    [XmlRoot(ElementName = "select")]
    public class Select
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
    public class Rules
    {
        [XmlElement(ElementName = "stat")]
        public List<Stat> Stat { get; set; }
        [XmlElement(ElementName = "grant")]
        public List<Grant> Grant { get; set; }
        [XmlElement(ElementName = "select")]
        public Select Select { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class Element
    {
        public string Description_Custom { get; set; }
        /* [XmlElement(ElementName = "description")]
         public Description Description { get; set; }*/
        [XmlElement(ElementName = "sheet")]
        public Sheet Sheet { get; set; }
        [XmlElement(ElementName = "setters")]
        public Setters Setters { get; set; }
        [XmlElement(ElementName = "rules")]
        public Rules Rules { get; set; }
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
    public class Tr
    {
        [XmlElement(ElementName = "td")]
        public List<string> Td { get; set; }
    }

    [XmlRoot(ElementName = "thead")]
    public class Thead
    {
        [XmlElement(ElementName = "tr")]
        public Tr Tr { get; set; }
    }

    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlElement(ElementName = "thead")]
        public Thead Thead { get; set; }
        [XmlElement(ElementName = "tr")]
        public List<Tr> Tr { get; set; }
    }

    [XmlRoot(ElementName = "div")]
    public class Div
    {
        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class Elements
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }

}
namespace Classes
{
    [XmlRoot(ElementName = "p")]
    public class P
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "i")]
        public List<string> I { get; set; }
        [XmlElement(ElementName = "strong")]
        public Strong Strong { get; set; }
        [XmlElement(ElementName = "em")]
        public string Em { get; set; }
    }

    [XmlRoot(ElementName = "li")]
    public class Li
    {
        [XmlElement(ElementName = "strong")]
        public string Strong { get; set; }
    }

    [XmlRoot(ElementName = "ul")]
    public class Ul
    {
        [XmlElement(ElementName = "li")]
        public List<Li> Li { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
    }

    [XmlRoot(ElementName = "h5")]
    public class H5
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "td")]
    public class Td
    {
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "tr")]
    public class Tr
    {
        [XmlElement(ElementName = "td")]
        public List<Td> Td { get; set; }
    }

    [XmlRoot(ElementName = "thead")]
    public class Thead
    {
        [XmlElement(ElementName = "tr")]
        public Tr Tr { get; set; }
    }

    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlElement(ElementName = "thead")]
        public Thead Thead { get; set; }
        [XmlElement(ElementName = "tr")]
        public List<Tr> Tr { get; set; }
        [XmlAttribute(AttributeName = "class")]
        public string Class { get; set; }
    }

    [XmlRoot(ElementName = "div")]
    public class Div
    {
        [XmlAttribute(AttributeName = "element")]
        public string Element { get; set; }
    }

    [XmlRoot(ElementName = "description")]
    public class Description
    {
        [XmlElement(ElementName = "p")]
        public List<P> P { get; set; }
        [XmlElement(ElementName = "h4")]
        public List<string> H4 { get; set; }
        [XmlElement(ElementName = "h3")]
        public string H3 { get; set; }
        [XmlElement(ElementName = "ul")]
        public List<Ul> Ul { get; set; }
        [XmlElement(ElementName = "h5")]
        public H5 H5 { get; set; }
        [XmlElement(ElementName = "table")]
        public Table Table { get; set; }
        [XmlElement(ElementName = "div")]
        public List<Div> Div { get; set; }
        [XmlElement(ElementName = "center")]
        public Center Center { get; set; }
    }

    [XmlRoot(ElementName = "sheet")]
    public class Sheet
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
    public class Set
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "setters")]
    public class Setters
    {
        [XmlElement(ElementName = "set")]
        public List<Set> Set { get; set; }
    }

    [XmlRoot(ElementName = "grant")]
    public class Grant
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
    public class Select
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
    public class Rules
    {
        [XmlElement(ElementName = "grant")]
        public List<Grant> Grant { get; set; }
        [XmlElement(ElementName = "select")]
        public List<Select> Select { get; set; }
        [XmlElement(ElementName = "stat")]
        public List<Stat> Stat { get; set; }
    }

    [XmlRoot(ElementName = "multiclass")]
    public class Multiclass
    {
        [XmlElement(ElementName = "prerequisite")]
        public string Prerequisite { get; set; }
        [XmlElement(ElementName = "requirements")]
        public string Requirements { get; set; }
        [XmlElement(ElementName = "setters")]
        public Setters Setters { get; set; }
        [XmlElement(ElementName = "rules")]
        public Rules Rules { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class Element
    {
        public string Description_Custom { get; set; }
        /*[XmlElement(ElementName = "description")]
        public Description Description { get; set; }*/
        [XmlElement(ElementName = "sheet")]
        public Sheet Sheet { get; set; }
        [XmlElement(ElementName = "setters")]
        public Setters Setters { get; set; }
        [XmlElement(ElementName = "rules")]
        public Rules Rules { get; set; }
        [XmlElement(ElementName = "multiclass")]
        public Multiclass Multiclass { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "spellcasting")]
        public Spellcasting Spellcasting { get; set; }
        [XmlElement(ElementName = "compendium")]
        public Compendium Compendium { get; set; }
        [XmlElement(ElementName = "supports")]
        public string Supports { get; set; }
    }

    [XmlRoot(ElementName = "center")]
    public class Center
    {
        [XmlElement(ElementName = "p")]
        public List<P> P { get; set; }
    }

    [XmlRoot(ElementName = "spellcasting")]
    public class Spellcasting
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
    public class Stat
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
    public class Compendium
    {
        [XmlAttribute(AttributeName = "display")]
        public string Display { get; set; }
    }

    [XmlRoot(ElementName = "strong")]
    public class Strong
    {
        [XmlElement(ElementName = "em")]
        public string Em { get; set; }
    }

    [XmlRoot(ElementName = "elements")]
    public class Elements
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Element { get; set; }
    }

}


