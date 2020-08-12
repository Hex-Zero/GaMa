using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameManagerUi.Models
{
    public enum GameTypes
    {
        Physical,
        Online
    }
    public class GameManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerLimit { get; set; }
        public GameTypes Type { get; set; }
    }
}
