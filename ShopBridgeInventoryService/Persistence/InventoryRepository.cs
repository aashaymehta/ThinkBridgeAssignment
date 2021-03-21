using System;
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
                return await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(itemId));
            }
        }

        public async Task<int> AddItem(Item item)
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                await inventoryDataContext.Items.AddAsync(item);
                await inventoryDataContext.SaveChangesAsync();
                return item.Id;
            }
        }

        public async Task<bool> RemoveItem(string itemId)
        {
            using (var inventoryDataContext = new InventoryDataContext())
            {
                var itemToBeDeleted = await inventoryDataContext.Items.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(itemId));
                if (itemToBeDeleted != null)
                {
                    inventoryDataContext.Items.Remove(itemToBeDeleted);
                    await inventoryDataContext.SaveChangesAsync();
                    return true;
                }

                return false;
                // await Task.FromResult(0);
            }
        }
    }
}
