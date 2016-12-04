using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LeaderId { get; set; }

        [Required]
        [ForeignKey("LeaderId")]
        public ApplicationUser Leader { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}