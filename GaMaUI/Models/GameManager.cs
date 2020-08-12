using System;
using System.Collections.Generic;
using System.Text;

namespace GaMaDataAccess.Models
{
    enum GameTypes
    {
        Physical,
        Online
    }
    class GameManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerLimit { get; set; }
        public GameTypes Type { get; set; }
    }
}
