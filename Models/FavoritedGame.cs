using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class FavoritedGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }

        public User user { get; set; }
    }
}
