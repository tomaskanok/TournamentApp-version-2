using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int WeightKg { get; set; }
        public bool SexMale { get; set; }
        public string Belt { get; set; }

        //public int RegistrationId { get; set; }

        //[Required]
        //[ForeignKey("RegistrationId")]
        //public Registration Registration { get; set; }

        public int TournamentId { get; set; }

        [Required]
        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }
        
        public bool? ClosedRegistation { get; set; }

        public Fight FinalFightId { get; set; }

        [ForeignKey("FinalFightId")]
        public int? FinalFight { get; set; }

    }
}