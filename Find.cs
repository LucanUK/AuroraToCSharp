using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraToCSharp
{
   internal class Find
   {
      
         public static RacesElement? FindRace(List<RacesElements> RacesList, string SearchRace)
         {


            var RacesListResult = RacesList.SelectMany(c => c.Element).Where(cr => cr.Type == "Race");

            foreach (var Race in RacesListResult.Where(Races => Races.Name == SearchRace)
                    )
            {

               return Race;
            }

            return null;
         }

         public static ClassesElement? FindClass(List<ClassesElements> ClassesList, string SearchClass)
         {


            var ClassListResult = ClassesList.SelectMany(c => c.Element).Where(cr => cr.Type == "Class");

            foreach (var Class in ClassListResult.Where(Classes => Classes.Name == SearchClass)
                    )
            {

               return Class;
            }

            return null;
         }

         public static ItemsElement? FindWeapon(List<ItemsElements> ItemsList, string SearchWeapon)
         {


            ItemsElements? WeaponsListResult = ItemsList[6];
            //var WeaponsListResult = ItemsListResult.  SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Weapon in WeaponsListResult.Element.Where(Weapons => Weapons.Name == SearchWeapon)
                    )
            {
               return Weapon;
            }

            return null;
         }

         public static ItemsElement? FindArmour(List<ItemsElements> ItemsList, string SearchArmour)
         {


            ItemsElements? ArmourListResult = ItemsList[0];
            //var WeaponsListResult = ItemsListResult.  SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");

            foreach (var Armour in ArmourListResult.Element.Where(Armours => Armours.Name == SearchArmour)
                    )
            {
               return Armour;
            }

            return null;
         }

         public static ItemsElement? FindItem(List<ItemsElements> ItemsList, string SearchItem)
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

         public static List<SpellsElement?> FindSpellAll(List<SpellsElements> SpellsList, string SearchSpell, string SearchClass, string SearchSpellLevel)
         {
            var                  SpellsListResult  = SpellsList.SelectMany(c => c.Element).Where(cr => cr.Type == "Spell");
            List<SpellsElement?> SpellSearchResult = new List<SpellsElement?>();

            /// Example - Better if
            var spellNameSearch = SearchSpell != null && SearchClass == null && SearchSpellLevel == null;

            if (spellNameSearch)
            {
               foreach (var Spell in SpellsListResult.Where(Spells => Spells.Name == SearchSpell))
               {

                  SpellSearchResult.Add(Spell);
               }

            }

            if (SearchSpell != null && SearchClass != null && SearchSpellLevel != null)
            {
               foreach (var Spell in SpellsListResult.Where(Spells => Spells.Name == SearchSpell))
               {

                  SpellSearchResult.Add(Spell);
               }

            }

            var spellClassSearch = SearchSpell == null && SearchClass != null && SearchSpellLevel == null;

            if (spellClassSearch)
            {

               SpellSearchResult = SpellsListResult.Where(Spells => Spells.Supports.Contains(SearchClass)).ToList();

            }

            if (SearchSpell == null && SearchClass != null && SearchSpellLevel != null)
            {

               var ClassSpellSearchResult = SpellsListResult.Where(Spells => Spells.Supports.Contains(SearchClass)).ToList();
               SpellSearchResult = ClassSpellSearchResult.Where(Spells => Spells.SpellsSetters.Set[1].Text == SearchSpellLevel).ToList();

            }

            if (SpellLevelSearch(SearchSpell, SearchClass, SearchSpellLevel))
            {

               SpellSearchResult = SpellsListResult.Where(Spells => Spells.Supports.Contains(SearchClass)).ToList();

            }

            return SpellSearchResult.ToList();

         }


      /// Example - Better if
      private static bool SpellLevelSearch(string? SearchSpell, string? SearchClass, string? SearchSpellLevel)
      {
         return SearchSpell == null && SearchClass == null && SearchSpellLevel != null;
      }
   }
}
