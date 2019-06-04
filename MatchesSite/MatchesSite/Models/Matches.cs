using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Matches
    {
        public int Id { get; set; }
        public int Home { get; set; }
        public int Away { get; set; }
        public DateTime? Date { get; set; }
        public int Bookie { get; set; }
        public double _1 { get; set; }
        public double X { get; set; }
        public double _2 { get; set; }
        public int? League { get; set; }
        public int? Country { get; set; }
        public string Hash { get; set; }
        public int? OpportunityId { get; set; }

        public Teams AwayNavigation { get; set; }
        public Bookies BookieNavigation { get; set; }
        public Countries CountryNavigation { get; set; }
        public Teams HomeNavigation { get; set; }
        public Leagues LeagueNavigation { get; set; }
        public Opportunities Opportunity { get; set; }
    }
}
