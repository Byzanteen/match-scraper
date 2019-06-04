using System;
using System.Collections.Generic;

namespace MatchesSite.Models
{
    public partial class Bookies
    {
        public Bookies()
        {
            Matches = new HashSet<Matches>();
            OpportunitiesId1Navigation = new HashSet<Opportunities>();
            OpportunitiesId2Navigation = new HashSet<Opportunities>();
            OpportunitiesIdXNavigation = new HashSet<Opportunities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
		public string Link { get; set; }
		public string ImageLink { get; set; }

        public ICollection<Matches> Matches { get; set; }
        public ICollection<Opportunities> OpportunitiesId1Navigation { get; set; }
        public ICollection<Opportunities> OpportunitiesId2Navigation { get; set; }
        public ICollection<Opportunities> OpportunitiesIdXNavigation { get; set; }
    }
}
