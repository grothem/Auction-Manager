using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual WinningBid WinningBid { get; set; }
    }
}
