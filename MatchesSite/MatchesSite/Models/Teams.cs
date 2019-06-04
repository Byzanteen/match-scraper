using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Teams
    {
        public Teams()
        {
            MatchesAwayNavigation = new HashSet<Matches>();
            MatchesHomeNavigation = new HashSet<Matches>();
            OpportunitiesAwayNavigation = new HashSet<Opportunities>();
            OpportunitiesHomeNavigation = new HashSet<Opportunities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Country { get; set; }
        public int? League { get; set; }

        public Countries CountryNavigation { get; set; }
        public Leagues LeagueNavigation { get; set; }
        public ICollection<Matches> MatchesAwayNavigation { get; set; }
        public ICollection<Matches> MatchesHomeNavigation { get; set; }
        public ICollection<Opportunities> OpportunitiesAwayNavigation { get; set; }
        public ICollection<Opportunities> OpportunitiesHomeNavigation { get; set; }
    }
}
