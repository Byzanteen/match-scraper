using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Opportunities
    {
        public Opportunities()
        {
            Matches = new HashSet<Matches>();
            Profits = new HashSet<Profits>();
        }

        public int Id { get; set; }
        public int Home { get; set; }
        public int Away { get; set; }
        public double _1 { get; set; }
        public double X { get; set; }
        public double _2 { get; set; }
        public int Id1 { get; set; }
        public int IdX { get; set; }
        public int Id2 { get; set; }
        public DateTime Date { get; set; }
        public int? League { get; set; }
        public int? Country { get; set; }
        public string Hash { get; set; }

        public Teams AwayNavigation { get; set; }
        public Countries CountryNavigation { get; set; }
        public Teams HomeNavigation { get; set; }
        public Bookies Id1Navigation { get; set; }
        public Bookies Id2Navigation { get; set; }
        public Bookies IdXNavigation { get; set; }
        public Leagues LeagueNavigation { get; set; }
        public ICollection<Matches> Matches { get; set; }
        public ICollection<Profits> Profits { get; set; }
    }
}
