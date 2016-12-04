using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Web { get; set; }

        public int Prize { get; set; }

        public string Info { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartRegistration { get; set; }

        public DateTime EndRegistration { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string OrganizerId { get; set; }

        [ForeignKey("OrganizerId")]
        public ApplicationUser Organizer { get; set; }
    }
}