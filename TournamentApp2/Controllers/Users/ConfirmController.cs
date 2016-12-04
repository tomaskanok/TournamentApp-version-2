using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TournamentApp2.Dtos;
using TournamentApp2.Models;

namespace TournamentApp2.Controllers.Users
{
    [Authorize]
    public class ConfirmController : ApiController
    {
        private ApplicationDbContext _context;

        public ConfirmController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult ConfirmFighter(ConfirmUserDto dto)
        {
            var userId = User.Identity.GetUserId();

            var loggedUser = _context.Users.Single(u => u.ShortIdentify == dto.userShortId);
            var user = _context.Users.Single(u => u.Id == userId);
            var team = _context.Teams.Single(t => t.Id == user.TeamId);

            if (team != null && user != null && loggedUser != null && loggedUser.TeamId == team.Id && user.TeamConfirmed == false)
            {
                user.TeamConfirmed = true;

                _context.SaveChanges();
            }
            else
            {
                BadRequest("Something went wrong.");
            }

            return Ok();
        }
    }
}
