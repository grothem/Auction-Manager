using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular.Models;
using Microsoft.EntityFrameworkCore;

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
        public Item GetItem(int id)
        {
            return _context.Items
                        .Include(i => i.WinningBid)
                            .ThenInclude(i => i.Bidder)
                        .Single(i => i.ID == id);
        }

        public void DeleteItem(int id)
        {
            var itemToDelete = _context.Items
                                    .Include(i => i.WinningBid)
                                    .Where(i => i.ID == id).FirstOrDefault();

            if (itemToDelete != null)
                _context.Remove(itemToDelete);
        }

        public void EditItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
