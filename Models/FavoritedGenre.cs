using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class FavoritedGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int UserId { get; set; }

        public Genre genre { get; set; }
        public User user { get; set; }
    }
}
