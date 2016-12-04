using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TournamentApp2.Models;
using TournamentApp2.ViewModels;

namespace TournamentApp2.Controllers
{
    public class TournamentsController : Controller
    {
        private ApplicationDbContext _context;

        public TournamentsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            // var upcomingTournaments = _context.Tournaments.Where(t => t.StartDate > DateTime.Now).ToList();
            var upcomingTournaments = _context.Tournaments.ToList();

            var tournaments = new TournamentsViewModel
            {
                Id = 1,
                UserIsLogged = userId == null ? false : true,
                TournamentsInfo = getTournamentInfoList(upcomingTournaments, userId)
            };

            return View(tournaments);
        }

        private List<TournamentInfo> getTournamentInfoList(List<Tournament> tournaments, string userId)
        {
            var tournamentInfo = new List<TournamentInfo>();

            int i = 0;
            foreach (var ut in tournaments)
            {
                i++;

                bool userRegistred = 0 < _context.Registrations.Where(r => r.UserId == userId && r.TournamentId == ut.Id).Count() ? true : false;

                tournamentInfo.Add(new TournamentInfo
                {
                    Id = i,
                    Tournament = ut,
                    UserRegistred = userRegistred,
                    UserPaid = userRegistred ? _context.Registrations.Where(r => r.UserId == userId && r.TournamentId == ut.Id).Single().Paid : false
                });
            }

            return tournamentInfo;
        }

        private TournamentInfo getTournamentInfo(Tournament tournament, string userId)
        {

            bool userRegistred = 0 < _context.Registrations.Where(r => r.UserId == userId && r.TournamentId == tournament.Id).Count() ? true : false;

            var registredFightersId = _context.Registrations.Where(r => r.TournamentId == tournament.Id).ToList();

            List<ApplicationUser> fighters = new List<ApplicationUser>();

            foreach (var fighter in registredFightersId)
            {
                fighters.Add(_context.Users.Single(u => u.Id == fighter.UserId));
            }

            return new TournamentInfo
            {
                Id = 1,
                Tournament = tournament,
                UserRegistred = userRegistred,
                UserPaid = userRegistred ? _context.Registrations.Where(r => r.UserId == userId && r.TournamentId == tournament.Id).Single().Paid : false,
                Fighters = fighters
            };
        }

        public ActionResult Detail(int Id)
        {
            var userId = User.Identity.GetUserId();

            var tournament = _context.Tournaments.Single(t => t.Id == Id);

            return View(getTournamentInfo(tournament, userId));
        }

        [Authorize]
        public ActionResult MyTournaments()
        {
            var userId = User.Identity.GetUserId();

            var tournaments = _context.Tournaments.Where(t => t.OrganizerId == userId);

            return View(tournaments);
        }
    }
}