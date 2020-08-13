using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameManagerUi.Models
{
    public class GameManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerLimit { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();

        public List<Match> Matches { get; set; } = new List<Match>();
    }

}
