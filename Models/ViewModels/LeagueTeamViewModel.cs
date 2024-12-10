using System.Collections.Generic;

namespace sportLeague.Models.ViewModels
{
    public class LeagueTeamViewModel
    {
        public League League { get; set; }
        public List<Team> Teams { get; set; }
    }
}
