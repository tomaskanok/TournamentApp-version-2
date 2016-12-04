using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TournamentApp2.Models;

namespace TournamentApp2.ViewModels
{
    public class TournamentsViewModel
    {
        [Key]
        public int Id { get; set; }

        public List<TournamentInfo> TournamentsInfo { get; set; }

        public bool UserIsLogged { get; set; }
    }

    public class TournamentInfo
    {
        [Key]
        public int Id { get; set; }

        public Tournament Tournament { get; set; }

        public bool UserRegistred { get; set; }

        public bool UserPaid { get; set; }

        public List<ApplicationUser> Fighters { get; set; }
    }
}