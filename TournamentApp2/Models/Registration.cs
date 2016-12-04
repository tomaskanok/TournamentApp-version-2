using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Paid { get; set; }

        public int GroupId { get; set; }

        [Required]
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public string UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int TournamentId { get; set; }

        [Required]
        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }

    }
}