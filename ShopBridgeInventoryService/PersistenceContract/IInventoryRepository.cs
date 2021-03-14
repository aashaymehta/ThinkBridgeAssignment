using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.Inventory.DomainModel;

namespace ShopBridge.Inventory.PersistenceContract
{
    public interface IInventoryRepository
    {
        Task<List<Item>> GetAllItems();

        Task<Item> GetItemById(string itemId);

        //Task<Item> AddItem(Item request);

        //Task<Item> RemoveItem(string itemId);

        Task AddItem(Item request);

        Task RemoveItem(string itemId);
    }
}
