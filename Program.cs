using System.Xml.Serialization;

namespace AuroraToCSharp
{
   internal class Program
   {
      private static void Main(string[] args)
      {

         string sourceFolderPath  = "C:\\Users\\714122\\Source\\Repos\\AuroraToCSharp-new\\XMLImport";
         string spellsFolderPath  = sourceFolderPath + "\\spells";
         string itemsFolderPath   = sourceFolderPath + "\\items";
         string racesFolderPath   = sourceFolderPath + "\\races";
         string classesFolderPath = sourceFolderPath + "\\classes";

         List<SpellsElements>  SpellsList  = new List<SpellsElements>();
         List<ItemsElements>   ItemsList   = new List<ItemsElements>();
         List<RacesElements>   RacesList   = new List<RacesElements>();
         List<ClassesElements> ClassesList = new List<ClassesElements>();

         static void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
         {
            if (e.ObjectBeingDeserialized is RacesElement raceElement)
            {
               if (e.Element.Name == "description")
               {
                  raceElement.Description_Custom = e.Element.InnerXml;
                  return;
               }
            }

            if (e.ObjectBeingDeserialized is ClassesElement classElement)
            {
               if (e.Element.Name == "description")
               {
                  classElement.Description_Custom = e.Element.InnerXml;
                  return;
               }
            }

            if (e.ObjectBeingDeserialized is ItemsElement itemElement)
            {
               if (e.Element.Name == "description")
               {
                  itemElement.Description_Custom = e.Element.InnerXml;
                  return;
               }
            }

            if (e.ObjectBeingDeserialized is SpellsElement spellElement)
            {
               if (e.Element.Name == "description")
               {
                  spellElement.Description_Custom = e.Element.InnerXml;
                  return;
               }
            }
         }

         if (Directory.Exists(spellsFolderPath))
         {
            DirectoryInfo dirSource      = new DirectoryInfo(spellsFolderPath);
            var           SpellsXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in SpellsXMLFiles)
            {
               try
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(SpellsElements));
                  serializer.UnknownElement += Serializer_UnknownElement;
                  using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                  {
                     SpellsElements spellsResult = serializer.Deserialize(reader) as SpellsElements;
                     SpellsList.Add(spellsResult);
                  }
               }
               catch (Exception ex)
               {

               }
            }
         }

         if (Directory.Exists(itemsFolderPath))
         {
            DirectoryInfo dirSource    = new DirectoryInfo(itemsFolderPath);
            var           ItemXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in ItemXMLFiles)
            {
               try
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(ItemsElements));
                  serializer.UnknownElement += Serializer_UnknownElement;
                  using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                  {
                     ItemsElements result = serializer.Deserialize(reader) as ItemsElements;
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
            DirectoryInfo dirSource   = new DirectoryInfo(racesFolderPath);
            var           AllXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in AllXMLFiles)
            {
               try
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(RacesElements));
                  serializer.UnknownElement += Serializer_UnknownElement;
                  using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                  {
                     RacesElements result = serializer.Deserialize(reader) as RacesElements;
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
            DirectoryInfo dirSource   = new DirectoryInfo(classesFolderPath);
            var           AllXMLFiles = dirSource.GetFiles("*.xml", SearchOption.AllDirectories).ToList();



            foreach (var nextFile in AllXMLFiles)
            {
               try
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(ClassesElements));
                  serializer.UnknownElement += Serializer_UnknownElement;
                  using (TextReader reader = new StringReader(File.ReadAllText(nextFile.FullName)))
                  {
                     ClassesElements result = serializer.Deserialize(reader) as ClassesElements;
                     ClassesList.Add(result);
                  }
               }
               catch (Exception ex)
               {

               }
            }
         }


         // Old Vars
         /*string SearchRace = "Elf";
         string SearchClass = "Druid";
         string SearchSpell = "Detect Magic";
         string SearchWeapon = "Rapier";
         string SearchArmour = "Ring Mail";
         string SearchItem = "Bag Of Holding";
         string SearchSpellLevel = "5";*/


         string SearchRace   = "Elf";
         string SearchWeapon = "Rapier";
         string SearchArmour = "Ring Mail";
         string SearchItem   = "Bag Of Holding";
         // SpellAll Test Vars
         string SearchClass      = "Druid";
         string SearchSpell      = null;
         string SearchSpellLevel = "2";


         RacesElement   RaceCurrent  = Find.FindRace(RacesList, SearchRace);
         ClassesElement ClassCurrent = Find.FindClass(ClassesList, SearchClass);

         ItemsElement WeaponCurrent = Find.FindWeapon(ItemsList, SearchWeapon);
         ItemsElement ArmourCurrent = Find.FindArmour(ItemsList, SearchArmour);
         ItemsElement ItemCurrent   = Find.FindItem(ItemsList, SearchItem);

         List<SpellsElement?> SpellSearchResult = Find.FindSpellAll(SpellsList: SpellsList, SearchSpell: SearchSpell, SearchClass: SearchClass, SearchSpellLevel: SearchSpellLevel);

         //Breakpoint marker
         int test = 1;


      }
   }
}




