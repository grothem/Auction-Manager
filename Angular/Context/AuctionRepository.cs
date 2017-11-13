using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models;

namespace Angular.Context
{
    public class AuctionRepository : IAuctionRepository
    {
        private AuctionContext _context;

        public AuctionRepository(AuctionContext context)
        {
            _context = context;
        }

        public void AddNewItem(Item newItem)
        {
            _context.Items.Add(newItem);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public IEnumerable<Item> GetLiveItems()
        {
            return _context.Items.Where(i => i.Type.Equals("live", StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public IEnumerable<Item> GetSilentItems()
        {
            return _context.Items.Where(i => i.Type.Equals("silent", StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
