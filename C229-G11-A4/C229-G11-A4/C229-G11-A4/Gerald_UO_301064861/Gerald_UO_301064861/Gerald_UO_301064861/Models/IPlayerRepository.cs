using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }

        void SavePlayer(Player player);

        Player DeletePlayer(int playerId);
        Player GetPlayer(int playerId);
        void TransferPlayer(Player player, int newClub);
    }
}
