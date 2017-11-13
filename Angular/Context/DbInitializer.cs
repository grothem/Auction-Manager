using Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Context
{
    public class DbInitializer
    {
        public static void Initialize(AuctionContext context)
        {
            context.Database.EnsureCreated();

            if (context.Items.Any())
                return;

            var silentItems = new List<Item>()
            {
                new Item { Number = "1", Description = "Chair", Type = "Silent" },
                new Item { Number = "2", Description = "Table", Type = "Silent" },
                new Item { Number = "3", Description = "Couch", Type = "Silent" }
            };

            silentItems.ForEach(i => context.Items.Add(i));
            context.SaveChanges();

            var liveItems = new List<Item>()
            {
                new Item { Number = "1", Description = "Gun", Type = "Live" },
                new Item { Number = "2", Description = "Bow", Type = "Live" },
                new Item { Number = "3", Description = "Dog", Type = "Live" }
            };

            liveItems.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
        }
    }
}
