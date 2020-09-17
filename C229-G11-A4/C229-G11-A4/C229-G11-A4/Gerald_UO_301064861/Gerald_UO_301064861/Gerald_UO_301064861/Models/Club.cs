using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public string ClubManager { get; set; }
        public string ClubBio { get; set; }

    }
}
