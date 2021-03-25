using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Inventory.DomainModel;

namespace ShopBridge.Inventory.PersistenceContract
{
    public interface IInventoryRepository
    {
        Task<List<Item>> GetAllItems();

        Task<Item> GetItemById(string itemId);

        Task<int> AddItem(Item request);

        Task<bool> UpdateItem(Item request);

        Task<bool> RemoveItem(string itemId);
    }
}
