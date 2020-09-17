using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerald_UO_301064861.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gerald_UO_301064861.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerRepository PlayerRepository;
        private IClubRepository ClubRepository;
        public PlayerController(IPlayerRepository repo, IClubRepository clubRepository)
        {
            PlayerRepository = repo;
            ClubRepository = clubRepository;
        }

        [Authorize]
        public IActionResult ManagePlayer()
        {
            ViewBag.ClubID = ClubsController.ACTIVE_CLUB.ClubID;
            ViewBag.ClubName = ClubsController.ACTIVE_CLUB.ClubName;
            ViewBag.ClubBio = ClubsController.ACTIVE_CLUB.ClubBio;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePlayer(string PlayerFirstname, string PlayerLastName, string PlayerPosition, DateTime DateOfBirth)
        {
            int clubId = ClubsController.ACTIVE_CLUB.ClubID;
            Club clubOBJ = ClubRepository.GetClub(clubId);
            string clubname = clubOBJ.ClubName;
            
            Player player = new Player(PlayerFirstname, PlayerLastName, PlayerPosition, DateOfBirth.Date, clubId);
            PlayerRepository.SavePlayer(player);
            ViewBag.ClubID = ClubsController.ACTIVE_CLUB.ClubID;
            ViewBag.ClubName = clubname;
            ViewBag.Bio = clubOBJ.ClubBio;

            return RedirectToAction("ClubInfo", "Clubs", new { id = clubId });
        }
        [Authorize]
        public ViewResult EditPlayer(int playerId)
        {
            Club clubOBJ = ClubRepository.GetClub(ClubsController.ACTIVE_CLUB.ClubID);

            ViewBag.ClubID = ClubsController.ACTIVE_CLUB.ClubID;
            ViewBag.ClubName = clubOBJ.ClubName;
            ViewBag.Bio = clubOBJ.ClubBio;

            return View("ManagePlayer", PlayerRepository.Players.FirstOrDefault(p => p.PlayerID == playerId));
        }
        [Authorize]
        public ViewResult TransferPlayer(int playerid) 
        {
            Player p = PlayerRepository.GetPlayer(playerid);
            Club clubOBJ = ClubRepository.GetClub(p.ClubID);
            ViewBag.ClubID = clubOBJ.ClubID;
            ViewBag.ClubName = clubOBJ.ClubName;
            ViewBag.Bio = clubOBJ.ClubBio;
            List<Club> otherClubs = ClubRepository.Clubs.Where(c => c.ClubID != p.ClubID).ToList();
            ViewBag.OtherClubs = otherClubs;
            return View(p);
        }
        [HttpPost]
        public IActionResult TransferPlayer(int playerid, int clubid)
        {
            Player player = PlayerRepository.GetPlayer(playerid);
            player.ClubID = clubid;
            PlayerRepository.SavePlayer(player);

            return RedirectToAction("ClubInfo", "Clubs", new { id = clubid });
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdatePlayer(Player player)
        {
            if(ModelState.IsValid)
            {
                int clubId = ClubsController.ACTIVE_CLUB.ClubID;
                player.ClubID = clubId;
                PlayerRepository.SavePlayer(player);

                return RedirectToAction("ClubInfo", "Clubs", new { id = clubId });
            }
            else
            {
                return View("ManagePlayer", player);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeletePlayer(int playerId)
        {
            Player deletePlayer = PlayerRepository.DeletePlayer(playerId);

            return RedirectToAction("ClubInfo", "Clubs", new { id = ClubsController.ACTIVE_CLUB.ClubID });
        }
    }
}