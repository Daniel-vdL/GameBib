using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class User
    {
        public static User CurrentUser { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? statusId { get; set; }

        public ICollection<FavoritedGame> FavoritedGames { get; set; }
        public ICollection<FavoritedGenre> FavoritedGenres { get; set; }
    }
}
