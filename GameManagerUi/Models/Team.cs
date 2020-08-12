using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagerUi.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public List<Player> Players { get; set; }
    }
}
