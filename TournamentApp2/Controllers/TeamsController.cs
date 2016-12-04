using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TournamentApp2.Models;
using TournamentApp2.ViewModels;
using static TournamentApp2.Models.Enums;


namespace TournamentApp2.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext _context;

        public TeamsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult All()
        {
            var teams = _context.Teams;

            var userId = User.Identity.GetUserId();

            if (userId == null)
                ViewBag.TeamAttending = 0;
            else
            {
                var user = _context.Users.Single(u => u.Id == userId);
                ViewBag.TeamAttending = user.TeamId;
            }

            return View(teams);
        }

        private TeamState GetTeamState(string userId, Team team)
        {
            if (userId != null)
            {
                var user = _context.Users.Single(u => u.Id == userId);

                if (user.TeamId != null)
                {
                    if (user.Team.Id == team.Id)
                        return user.TeamConfirmed ? TeamState.Yes : TeamState.Waiting;
                    else
                        return TeamState.InAnotherTeam;
                }
                else
                {
                    return TeamState.No;
                }
            }
            else
            {
                return TeamState.NoUser;
            }
        }

        public ActionResult Detail(int Id)
        {
            var userId = User.Identity.GetUserId();

            var team = _context.Teams.Single(t => t.Id == Id);

            if (team == null)
            {
                return HttpNotFound();
            }

            var teamDetail = new TeamDetailViewModel
            {
                Team = team,
                Fighters = _context.Users
                    .Where(u => u.TeamId == team.Id && u.TeamConfirmed)
                    .ToList(),
                WaitingFighters = _context.Users
                    .Where(u => u.TeamId == team.Id && !u.TeamConfirmed ) // TO DO - vybrat jen pokud je prihlaseny leader teamu
                    .ToList(),
                Coach = _context.Users.Single(u => u.Id == team.LeaderId),
                UserIsLogged = userId == null ? false : true,
                TeamState = GetTeamState(userId, team)
            };

            return View(teamDetail);
        }
    }
}