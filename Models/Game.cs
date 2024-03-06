using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Release { get; set; }
        public double Rating { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        
        public ICollection<FavoritedGame> FavoritedGames { get; set; }
    }
}
