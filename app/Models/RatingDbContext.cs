using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace vintri.Models
{
    public class RatingDbContext
    {
        private const string FILENAME = "database.json";
        public IList<UserRating> UserRatings { get; private set; } = new List<UserRating>();

        public void Add(UserRating UserRating)
        {
            UserRatings.Add(UserRating);
        }

        public void SaveChanges()
        {
            try
            {
                var @path = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);
                string json = JsonConvert.SerializeObject(UserRatings);
                File.WriteAllText(path, json);

            }
            catch (System.Exception)
            {
                throw new System.Exception("Unable to Save User Rating");
            }
        }

        public void LoadJSON()
        {
            if (!UserRatings.Any())
            {
                try
                {
                    var @path = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);
                    var json = File.ReadAllText(path);
                    UserRatings = JsonConvert.DeserializeObject<List<UserRating>>(json);
                    System.Console.WriteLine($"Count: {UserRatings.Count()}");
                }
                catch (System.Exception)
                {
                    throw new System.Exception("Unable to Load JSON");
                }
            }
        }
    }
}