using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public string PlayerFirstname { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerPosition { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClubID { get; set; }
        public virtual Club PlayerClub { get; set; }


        public Player()
        {

        }

        public Player(string fname, string lname, string pos, DateTime dob, int club)
        {
            PlayerFirstname = fname;
            PlayerLastName = lname;
            PlayerPosition = pos;
            DateOfBirth = dob.Date;
            ClubID = club;
        }


    }
}
