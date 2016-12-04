using TournamentApp2.Models;

namespace TournamentApp2.ViewModels
{
    public class FighterViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get { return this.FirstName + " " + this.LastName; } }

        public Team Team { get; set; }
    }
}