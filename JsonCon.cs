using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Text.Json.Serialization;
using Google.Cloud.Firestore;


namespace AuroraToCSharp
{
    class JSONFireBase
    {

        public static async Task JsonSpellsAsync(List<SpellsElement> SpellsList)
        {
            
            try
            {
                var JSONString = System.Text.Json.JsonSerializer.Serialize(SpellsList);
                var spellObject = System.Text.Json.JsonSerializer.Deserialize<List<SpellObject>>(JSONString);
                FirestoreDb db = FirestoreDb.Create("players-playbook");
                Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "players-playbook");

                await Parallel.ForEachAsync (spellObject, async (spell, token) =>
                {
                    var dict = spell.SpellsSetters.Set.ToDictionary(x => x.Name, y=> y.Text);
                    DocumentReference document = db.Collection("spells").Document(spell.Id);
                    await document.SetAsync(new { Name = spell.Name, Type = spell.Type, SourceBook = spell.Source, Supports = spell.Supports, Setters = dict, SpellDescription = spell.Description_Custom }); ;

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
