using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Models
{
    public class WinningBid
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int BidderID { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }

        public virtual Item Item { get; set; }
        public virtual Bidder Bidder { get; set; }

    }
}
