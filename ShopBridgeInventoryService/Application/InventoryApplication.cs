using System.Collections.Generic;
using System.Threading.Tasks;
using ShopBridge.Inventory.ApplicationContract;
using ShopBridge.Inventory.DomainModel;
using ShopBridge.Inventory.PersistenceContract;

namespace ShopBridge.Inventory.Application
{
    public class InventoryApplication: IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<GetItemsResponse> GetAllItems()
        {
            var items = await _inventoryRepository.GetAllItems();
            var itemsDto = new List<ItemDto>();
            foreach (var item in items)
            {
                itemsDto.Add(new ItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description
                });
            }
            return new GetItemsResponse()
            {
                Items = itemsDto
            };
        }

        public async Task<GetItemByIdResponse> GetItemById(string itemId)
        {
            var item = await _inventoryRepository.GetItemById(itemId);
            
            return new GetItemByIdResponse()
            {
                Item = new ItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description
                }
            };
        }

        public async Task<AddItemResponse> AddItem(AddItemRequest request)
        {
            var itemToBeAdded = new Item()
            {
                Name = request.Item.Name,
                Description = request.Item.Description,
                Price = request.Item.Price,
                Id = request.Item.Id
            };
            await _inventoryRepository.AddItem(itemToBeAdded);
            return new AddItemResponse();
        }

        public async Task<RemoveItemResponse> RemoveItem(string itemId)
        {
            await _inventoryRepository.RemoveItem(itemId);
            return new RemoveItemResponse();
        }
    }
}
