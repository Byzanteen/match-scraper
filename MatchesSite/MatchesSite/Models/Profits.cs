using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Profits
    {
        public int Id { get; set; }
        public double IsPossible { get; set; }
        public double Percent1 { get; set; }
        public double PercentX { get; set; }
        public double Percent2 { get; set; }
        public double Roi { get; set; }
        public int OpportunityId { get; set; }

        public Opportunities Opportunity { get; set; }
    }
}
