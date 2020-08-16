using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameManagerUi.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public int ManagerId { get; set; }
    }
}
