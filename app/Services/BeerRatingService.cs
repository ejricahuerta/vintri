using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vintri.Helpers;
using vintri.Models;

namespace vintri.Services
{
    public class BeerRatingService : IBeerRatingService
    {
        private const string API_PATH = "https://api.punkapi.com/v2/beers";
        private const string PARAM_NAME = "beer_name";
        private const string PARAM_ID = "ids";
        public readonly RatingDbContext userRatingDb;
        public BeerRatingService(RatingDbContext userRatingDb)
        {
            this.userRatingDb = userRatingDb;
        }

        public async Task<List<Beer>> ListBeerByName(string name = null)
        {
            string url = $"{API_PATH}?{PARAM_NAME}={name}";
            if (string.IsNullOrEmpty(name))
            {
                url = $"{API_PATH}";
            }
            var response = await HttpClientHelper.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            var beers = JsonConvert.DeserializeObject<List<Beer>>(responseBody);
            return beers.Select(p =>
            {
                p.UserRatings = userRatingDb.UserRatings
                                            .Where(r => r.Id == p.Id)
                                            .Select(u => new UserRatingDetail
                                            {
                                                Username = u.Username,
                                                Comments = u.Comments,
                                                Rating = u.Rating
                                            })
                                            .ToList();
                return p;
            }).ToList();
        }

        public async Task RateBeer(int id, UserRatingDetail userRating)
        {
            if (userRating == null)
            {
                throw new System.ArgumentException("Invalid User Rating");
            }

            var response = await HttpClientHelper.GetAsync($"{API_PATH}?{PARAM_ID}={id}");
            string responseBody = await response.Content.ReadAsStringAsync();
            var beers = JsonConvert.DeserializeObject<List<Beer>>(responseBody);

            if (beers.Any())
            {
                userRatingDb.Add(new UserRating
                {
                    Id = id,
                    Username = userRating.Username,
                    Comments = userRating.Comments,
                    Rating = userRating.Rating
                });

                userRatingDb.SaveChanges();
            }
            else
            {
                throw new System.ArgumentException("Beer Does not Exist");
            }
        }
    }
}