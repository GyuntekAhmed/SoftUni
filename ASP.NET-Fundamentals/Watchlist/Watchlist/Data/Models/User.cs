using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UsersMovies = new List<UserMovie>();
        }

        public List<UserMovie> UsersMovies { get; set; }
    }
}
