using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagerUi.Models
{
    public  class Match
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; } = new Team();
        public Team AwayTeam { get; set; } = new Team();
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int GameManagerId { get; set; }
    }
}
