using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public interface IClubRepository
    {
        IQueryable<Club> Clubs { get; }

        void SaveClub(Club club);

        Club DeleteClub(int clubID);

        Club GetClub(int clubID);
    }
}
