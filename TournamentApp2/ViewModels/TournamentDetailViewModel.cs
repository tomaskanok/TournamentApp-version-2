using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TournamentApp2.Models;

namespace TournamentApp2.ViewModels
{
    public class TournamentDetailViewModel
    {
        public Tournament Tournament { get; set; }

        public List<FighterViewModel> Fighters {get;set;}

        public bool UserRegistred { get; set; }

        public bool UserPaid { get; set; }
    }
}