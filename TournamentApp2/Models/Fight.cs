using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Fight
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public DateTime? TimeEnd { get; set; }

        public bool? Overtime { get; set; }

        public string WayOfWin { get; set; }

        public int? PointsFirst { get; set; }

        public int? PointsSecond { get; set; }
        
        public string ApplicationUserRefereeId { get; set; }

        [ForeignKey("ApplicationUserRefereeId")]
        public ApplicationUser ApplicationUserReferee { get; set; }

        public string ApplicationUserFighterFirstId { get; set; }

        [ForeignKey("ApplicationUserFighterFirstId")]
        public ApplicationUser ApplicationUserFighterFirst { get; set; }

        public string ApplicationUserFighterSecondId { get; set; }

        [ForeignKey("ApplicationUserFighterSecondId")]
        public ApplicationUser ApplicationUserFighterSecond { get; set; }

        public int? RootFightId { get; set; }

        [ForeignKey("RootFightId")]
        public Fight RootFight { get; set; }
    }
}