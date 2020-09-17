using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        ApplicationDbContext context;

        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Player> Players => context.Players;

        public void SavePlayer(Player player)
        {
            if (player.PlayerID == 0)
            {
                context.Players.Add(player);
            }
            else
            {
                Player dbEntry = context.Players
                .FirstOrDefault(p => p.PlayerID == player.PlayerID);

                if (dbEntry != null)
                {
                    dbEntry.PlayerFirstname = player.PlayerFirstname;
                    dbEntry.PlayerLastName = player.PlayerLastName;
                    dbEntry.PlayerPosition = player.PlayerPosition;
                    dbEntry.DateOfBirth = player.DateOfBirth.Date;
                    dbEntry.ClubID = player.ClubID;
                }
            }
            context.SaveChanges();
        }

        public Player DeletePlayer(int playerId)
        {
            Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == playerId);

            if(dbEntry != null)
            {
                context.Players.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

        public Player GetPlayer(int playerId)
        {
            Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == playerId);
            return dbEntry;
        }

        public void TransferPlayer(Player player, int newClub)
        {
            Player dbEntry = context.Players.FirstOrDefault(p => p.PlayerID == player.PlayerID);
            dbEntry.ClubID = newClub;
            context.SaveChanges();
        }
    }
}
