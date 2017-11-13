using Angular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Context
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<WinningBid> WinningBids { get; set; }
    }
}
