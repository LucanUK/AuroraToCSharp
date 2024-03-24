using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using Google.Cloud.Firestore;


namespace AuroraToCSharp
{
    class JSONFireBase
    {

        //public static async Task DoSpellAsync(SpellObject Spell)
        //{
        //    try
        //    {
                
        //        //CollectionReference collection = db.Collection("/spells");
        //        DocumentReference document = db.Collection("spells").Document(Spell.Id);
        //        //document.SetAsync(new { Name = Spell.Name, Type = Spell.Type, SourceBook = Spell.Source, Supports = Spell.Supports, SpellDescription = Spell.Description_Custom }); ;
        //        Dictionary<string, object> spelldata = new Dictionary<string, object>
        //        {
        //            { "Name", Spell.Name },
        //            { "Type", Spell.Type },
        //            { "Source", Spell.Source },
        //            { "Supports", Spell.Supports },
        //            { "Description", Spell.Description_Custom },
        //            };

        //        await document.SetAsync(spelldata);
        //        //document.CreateAsync(new { Name = Spell.Name, Type = Spell.Type, SourceBook = Spell.Source, Supports = Spell.Supports, SpellDescription = Spell.Description_Custom });
        //        //Console.WriteLine(response);
        //        var something = 1;
        //    } catch (Exception ex)
        //    {

        //    }
        //    return;
        //}

        public static async Task JsonSpellsAsync(List<SpellsElement> SpellsList)
        {
            
            try
            {
                var JSONString = JsonSerializer.Serialize(SpellsList);
                var spellObject = JsonSerializer.Deserialize<List<SpellObject>>(JSONString);
                FirestoreDb db = FirestoreDb.Create("players-playbook");
                Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "players-playbook");

                await Parallel.ForEachAsync (spellObject, async (spell, token) =>
                {
                    DocumentReference document = db.Collection("spells").Document(spell.Id);
                    await document.SetAsync(new { Name = spell.Name, Type = spell.Type, SourceBook = spell.Source, Supports = spell.Supports, SpellDescription = spell.Description_Custom }); ;

                });
                var something = 1;
            }
            catch (Exception ex)
            {

            }
            return;
          
        }
    }

    public class RootObject
    {
        public SpellObject[] Property1 { get; set; }
    }

    public class SpellObject
    {
        public string Supports { get; set; }
        public string Description_Custom { get; set; }
        public Spellssetters SpellsSetters { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Id { get; set; }
    }

    public class Spellssetters
    {
        public Set[] Set { get; set; }
    }

    public class Set
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }

}
