using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models.ViewModels
{
    public class ClubRegPlayers
    {
        public Club club { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
