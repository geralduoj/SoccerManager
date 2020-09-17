//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Gerald_UO_301064861.Models
//{
//    public class MyClubRepository : IClubRepository
//    {
//        public static List<Club> newClubs = new List<Club>
//        {
//            new Club("Chelsea", "Frank Lampard", "Chelsea Football Club are an English professional football club based in Fulham, London. Founded in 1905" ),
//            new Club("Manchester United", "Ole Gunnar Solskjær", "Manchester United Football Club is a professional football club based in Old Trafford, Greater Manchester, England." ),
//            new Club("Liverpool", "Jürgen Klopp", "Liverpool Football Club is a professional football club in Liverpool, England, that competes in the Premier League" ),
//            new Club("Manchester City", "Pep Guardila", "Manchester City Football Club is an English football club based in Manchester, that competes in the Premier League." ),
//            new Club("Tottenham Hotspur", "José Mourinho", "Tottenham Hotspur Football Club, commonly referred to as Tottenham or Spurs, is an English professional club." ),
//            new Club("Arsenal", "Mikel Arteta", "Arsenal Football Club is a professional football club based in Islington, London, England, that plays in the Premier League")
//        };
//        public IQueryable<Club> Clubs => newClubs.AsQueryable<Club>();

//        public static void AddNewClub(Club club) 
//        {
//            newClubs.Add(club);
//        }

//        public static Club GetClub(int id) 
//        {
//            return newClubs.SingleOrDefault(c => c.ClubID == id);
//        }
//    }
//}
