using NUnit.Framework;
using vintri.Models;
using vintri.Services;
using System.Linq;
using System.Threading.Tasks;
namespace test
{

    public class VintriTest
    {
        public RatingDbContext Context { get; set; }
        public IBeerRatingService BeerRating { get; set; }

        public UserRating UserRating { get; set; }
        [SetUp]
        public void Setup()
        {
            Context = new RatingDbContext();
            BeerRating = new BeerRatingService(Context);

        }

        [Test]
        public void Can_Add_New_Rating()
        {
            UserRating = new UserRating
            {
                Id = 1,
                Username = "test@abc.com",
                Rating = 1
            };

            Context.Add(UserRating);

            Assert.IsTrue(Context.UserRatings.Any());
        }

        [Test]
        public async Task Can_List_Beers(){

            var name = "Beer";
            var result =  await BeerRating.ListBeerByName(name);
            
            Assert.IsTrue(result.Any(p=>p.Name.Contains(name)));
        }
    }
}