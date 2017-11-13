using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class Bidder
    {
        public int ID { get; set; }
        public int BidNumber { get; set; }
        public virtual ICollection<WinningBid> WinningBids { get; set; }
    }
}
