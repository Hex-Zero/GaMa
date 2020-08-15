using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameManagerUi.Models
{
    public class GameManager
    {
        public int GameManagerId { get; set; }
       public string Name { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public string Representative { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();

        public List<Match> Matches { get; set; } = new List<Match>();
    }
    public static class ManagerId
    {
       public static int Id { get; set; }
       public static string Name { get; set; }
    }
}
