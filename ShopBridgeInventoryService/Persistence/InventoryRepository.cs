using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Inventory.DomainModel;
using ShopBridge.Inventory.PersistenceContract;

namespace ShopBridge.Inventory.Persistence
{
    public class InventoryRepository: IInventoryRepository
    {
        public async Task<List<Item>> GetAllItems()
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                return await inventoryDataContext.Items.ToListAsync();
            }
        }

        public async Task<Item> GetItemById(string itemId)
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                return await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == itemId);
            }
        }

        public async Task AddItem(Item item)
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                await inventoryDataContext.Items.AddAsync(item);
                await inventoryDataContext.SaveChangesAsync();
                await Task.FromResult(0);
            }
        }

        public async Task RemoveItem(string itemId)
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                var itemToBeDeleted = await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == itemId);
                if (itemToBeDeleted != null)
                {
                    inventoryDataContext.Items.Remove(itemToBeDeleted);
                    await inventoryDataContext.SaveChangesAsync();
                }
                await Task.FromResult(0);
            }
        }
    }
}
