using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameManagerUi.Models
{
    public  class Match
    {
        public int MatchId { get; set; }
        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        [Display(Name = "Home Score")]
        public int HomeScore { get; set; }
        [Display(Name = "Away Score")]
        public int AwayScore { get; set; }
        public bool MatchFinished { get; set; }
        public DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public string Code { get; set; }
    }
}
