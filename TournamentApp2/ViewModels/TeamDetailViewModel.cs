using System.Collections.Generic;
using TournamentApp2.Models;
using static TournamentApp2.Models.Enums;

namespace TournamentApp2.ViewModels
{

    public class TeamDetailViewModel
    {
        public Team Team { get; set; }

        public ApplicationUser Coach { get; set; }

        public List<ApplicationUser> Fighters { get; set; }

        public List<ApplicationUser> WaitingFighters { get; set; }

        public TeamState TeamState { get; set; }

        public bool UserIsLogged { get; set; }
    }
}