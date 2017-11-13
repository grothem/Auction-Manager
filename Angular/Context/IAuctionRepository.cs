using Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Context
{
    public interface IAuctionRepository
    {
        IEnumerable<Item> GetAllItems();
        IEnumerable<Item> GetSilentItems();
        IEnumerable<Item> GetLiveItems();
        void AddNewItem(Item newItem);
        Task<bool> SaveChangesAsync();
    }
}
