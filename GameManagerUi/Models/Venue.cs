using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameManagerUi.Models
{
   public class Venue
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public int TeamId { get; set; }
    }
}
