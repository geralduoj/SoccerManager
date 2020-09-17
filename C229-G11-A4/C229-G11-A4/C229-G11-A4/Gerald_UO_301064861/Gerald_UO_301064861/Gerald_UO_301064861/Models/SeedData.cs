using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerald_UO_301064861.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app) 
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Clubs.Any()) 
            {
                context.Clubs.AddRange(
                    new Club { ClubName = "Chelsea", ClubManager = "Frank Lampard", ClubBio = "Chelsea Football Club are an English professional football club based in Fulham, London. Founded in 1905" },
                    new Club { ClubName = "Manchester United", ClubManager = "Ole Gunnar Solskjær", ClubBio = "Manchester United Football Club is a professional football club based in Old Trafford, Greater Manchester, England." },
                    new Club { ClubName = "Liverpool", ClubManager = "Jürgen Klopp", ClubBio = "Liverpool Football Club is a professional football club in Liverpool, England, that competes in the Premier League" },
                    new Club { ClubName = "Manchester City", ClubManager = "Pep Guardila", ClubBio = "Manchester City Football Club is an English football club based in Manchester, that competes in the Premier League." },
                    new Club { ClubName = "Tottenham Hotspur", ClubManager = "José Mourinho", ClubBio = "Tottenham Hotspur Football Club, commonly referred to as Tottenham or Spurs, is an English professional club." },
                    new Club { ClubName = "Arsenal", ClubManager = "Mikel Arteta", ClubBio = "Arsenal Football Club is a professional football club based in Islington, London, England, that plays in the Premier League" }
                    );
                context.SaveChanges();

            }
        }
    }
}
