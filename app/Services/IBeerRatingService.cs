using System.Collections.Generic;
using System.Threading.Tasks;
using vintri.Models;

namespace vintri.Services
{
    public interface IBeerRatingService
    {
        Task RateBeer(int id,UserRatingDetail userRating);

        Task<List<Beer>> ListBeerByName(string name);
    }
}