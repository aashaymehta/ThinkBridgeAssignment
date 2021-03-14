using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Inventory.DomainModel;
using ShopBridge.Inventory.PersistenceContract;

namespace ShopBridge.Inventory.Persistence
{
    public class InventoryRepository: IInventoryRepository
    {
        private List<Item> _items;

        public InventoryRepository()
        {
            _items = new List<Item>();
            _items.Add(new Item()
            {
                Description = "Item1 description",
                Price = 100,
                Name = "Item1",
                Id = "101"
            });
            _items.Add(new Item()
            {
                Description = "Item2 description",
                Price = 200,
                Name = "Item2",
                Id = "102"
            });
            _items.Add(new Item()
            {
                Description = "Item3 description",
                Price = 300,
                Name = "Item3",
                Id = "103"
            });
            _items.Add(new Item()
            {
                Description = "Item4 description",
                Price = 400,
                Name = "Item4",
                Id = "104"
            });
            _items.Add(new Item()
            {
                Description = "Item5 description",
                Price = 500,
                Name = "Item5",
                Id = "105"
            });
        }
        public async Task<List<Item>> GetAllItems()
        {
            return _items;
        }

        public async Task<Item> GetItemById(string itemId)
        {
            return _items.Find(x => x.Id == itemId);
        }

        public async Task<Item> AddItem(Item item)
        {
            _items.Add(item);
            return item;
        }

        public async Task<Item> RemoveItem(string itemId)
        {
            var itemToBeDeleted = _items.Find(x => x.Id == itemId);
            if (itemToBeDeleted != null)
            {
                _items.Remove(itemToBeDeleted);
            }

            return itemToBeDeleted;
        }
    }
}
