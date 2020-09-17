using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public class EFClubRepository : IClubRepository
    {
        ApplicationDbContext context;

        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Club> Clubs => context.Clubs;

        public Club DeleteClub(int clubID)
        {
            Club dbEntry = context.Clubs.FirstOrDefault(p => p.ClubID == clubID);
            if (dbEntry != null)
            {
                context.Clubs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Club GetClub(int clubID)
        {
            Club dbEntry = context.Clubs.FirstOrDefault(p => p.ClubID == clubID);
            return dbEntry;
        }

        public void SaveClub(Club club)
        {
            if (club.ClubID == 0)
            {
                context.Clubs.Add(club);
            }
            else
            {
                Club dbEntry = context.Clubs
                .FirstOrDefault(p => p.ClubID == club.ClubID);
                if (dbEntry != null)
                {
                    dbEntry.ClubName = club.ClubName;
                    dbEntry.ClubBio = club.ClubBio;
                    dbEntry.ClubManager = club.ClubManager;
                }
            }
            context.SaveChanges();
        }
    }
}
