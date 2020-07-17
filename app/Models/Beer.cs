
using System.Collections.Generic;

namespace vintri.Models
{

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRatingDetail> UserRatings { get; set; } = new List<UserRatingDetail>();

    }

}