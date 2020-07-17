using System.ComponentModel.DataAnnotations;

namespace vintri.Models
{

    public class UserRating : UserRatingDetail
    {
        public int Id { get; set; }

    }

    public class UserRatingDetail
    {
        [Required(ErrorMessage = "Username cannot be null or empty")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessage = "Invalid Email Address")]
        public string Username { get; set; }

        [Range(1, 5, ErrorMessage = "Rating is Invalid. Please rate from 1 to 5 only")]
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}