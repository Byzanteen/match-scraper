using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Leagues = new HashSet<Leagues>();
            Matches = new HashSet<Matches>();
            Opportunities = new HashSet<Opportunities>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
		public string Flag { get; set; }

        public ICollection<Leagues> Leagues { get; set; }
        public ICollection<Matches> Matches { get; set; }
        public ICollection<Opportunities> Opportunities { get; set; }
        public ICollection<Teams> Teams { get; set; }
    }
}
