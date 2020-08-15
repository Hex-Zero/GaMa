using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameManagerUi.Models
{
    public  class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool MatchFinished { get; set; }
        public DateTime Data { get; set; }
        public int ManagerId { get; set; }
        public string Code { get; set; }
    }
}
