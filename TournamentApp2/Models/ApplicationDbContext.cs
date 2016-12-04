using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Fight> Fights { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasRequired(b => b.Tournament)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .HasRequired(b => b.Group)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                    .HasOptional<Team>(s => s.Team)
                    .WithMany(s => s.ApplicationUsers)
                    .HasForeignKey(s => s.TeamId);

            base.OnModelCreating(modelBuilder);
        }
    }
}