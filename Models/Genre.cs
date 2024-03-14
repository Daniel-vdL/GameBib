using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Game> Games { get; set; }
        public ICollection<FavoritedGame> FavoritedGames { get; set; }
    }
}
