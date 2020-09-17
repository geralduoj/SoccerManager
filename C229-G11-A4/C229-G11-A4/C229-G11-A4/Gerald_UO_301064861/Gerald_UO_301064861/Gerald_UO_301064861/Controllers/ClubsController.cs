using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerald_UO_301064861.Models;
using Gerald_UO_301064861.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gerald_UO_301064861.Controllers
{
    public class ClubsController : Controller
    {
        private IClubRepository repository;
        private IPlayerRepository player_repository;
        public static Club ACTIVE_CLUB;

        public ClubsController(IClubRepository repos, IPlayerRepository playerRepo)
        {
            repository = repos;
            player_repository = playerRepo;
        }
        public ViewResult AllClubs()
        {
            return View(new ClubListViewModel
            {
                Clubs = repository.Clubs
            });
        }
        public ViewResult ClubInfo(int id)
        {
            ACTIVE_CLUB = repository.Clubs.FirstOrDefault(p => p.ClubID == id);
            List<Player> myplayers = player_repository.Players.Where(p => p.ClubID == id).ToList();
            ViewBag.Players = myplayers;

            return View(ACTIVE_CLUB);
        }
        [Authorize]
        public ViewResult EditClub(int clubid) => 
            View(repository.Clubs
            .FirstOrDefault(p => p.ClubID == clubid));

        [HttpPost]
        [Authorize]
        public IActionResult EditClub(Club club) 
        {
            repository.SaveClub(club);
            List<Player> myplayers = player_repository.Players.Where(p => p.ClubID == club.ClubID).ToList();
            ViewBag.Players = myplayers;
            return View("ClubInfo", club);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddClub(Club club)
        {
            repository.SaveClub(club);
            return View("SuccessfulClubRegister", club);
        }

        
        [HttpGet]
        [Authorize]
        public ViewResult AddClub() 
        {
            return View(new Club());
        }

        [HttpGet]
        [Authorize]
        public IActionResult DeleteClub(int clubID) 
        { 
            repository.DeleteClub(clubID);
            return RedirectToAction("AllClubs");
        }
    }
}