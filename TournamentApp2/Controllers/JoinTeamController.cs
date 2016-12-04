using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TournamentApp2.Dtos;
using TournamentApp2.Models;

namespace TournamentApp2.Controllers
{
    [Authorize]
    public class JoinTeamController : ApiController
    {
        private ApplicationDbContext _context;

        public JoinTeamController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Join(JoinTeamDto dto)
        {
            var userId = User.Identity.GetUserId();

            var user = _context.Users.Single(u => u.Id == userId);

            if (user.TeamId == null)
            {
                user.TeamId = dto.TeamId;
                
                _context.SaveChanges();
            }
            else
            {
                BadRequest("You are already in some team.");
            }

            return Ok();
        }
    }
}
