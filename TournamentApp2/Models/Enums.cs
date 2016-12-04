using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentApp2.Models
{
    public class Enums
    {
        public enum TeamState
        {
            No, 
            Waiting,
            Yes,
            InAnotherTeam,
            NoUser // no user is logged
        };

    }
}