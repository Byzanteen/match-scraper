using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Leagues
    {
        public Leagues()
        {
            Matches = new HashSet<Matches>();
            Opportunities = new HashSet<Opportunities>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Country { get; set; }

        public Countries CountryNavigation { get; set; }
        public ICollection<Matches> Matches { get; set; }
        public ICollection<Opportunities> Opportunities { get; set; }
        public ICollection<Teams> Teams { get; set; }
    }
}
