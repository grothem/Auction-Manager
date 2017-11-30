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
        Item GetItem(int id);
        void AddNewItem(Item newItem);
        void DeleteItem(int id);
        void EditItem(Item item);
        Task<bool> SaveChangesAsync();
    }
}
