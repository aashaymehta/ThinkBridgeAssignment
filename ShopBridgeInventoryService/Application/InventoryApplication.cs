﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
            try
            {
                var items = await _inventoryRepository.GetAllItems();
                var itemsDto = new List<ItemDto>();
                foreach (var item in items)
                {
                    itemsDto.Add(new ItemDto()
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Price = item.Price.ToString(CultureInfo.InvariantCulture),
                        Description = item.Description
                    });
                }

                return new GetItemsResponse()
                {
                    Items = itemsDto
                };
            }
            catch (Exception ex)
            {
                return new GetItemsResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
            
        }

        public async Task<GetItemByIdResponse> GetItemById(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
                {
                    throw new Exception("Item id is not valid !");
                }
                var item = await _inventoryRepository.GetItemById(itemId);

                if (item == null)
                {
                    return new GetItemByIdResponse()
                    {
                        ErrorMessage = "The item with specified id could not be found!"
                    };
                }
                return new GetItemByIdResponse()
                {
                    Item = new ItemDto()
                    {
                        Id = item.Id.ToString(),
                        Name = item.Name,
                        Price = item.Price.ToString(CultureInfo.InvariantCulture),
                        Description = item.Description
                    }
                };
            }
            catch (Exception ex)
            {
                return new GetItemByIdResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<AddItemResponse> AddItem(AddItemRequest request)
        {
            try
            {
                Validate(request);
                var itemToBeAdded = new Item()
                {
                    Name = request.Item.Name,
                    Description = request.Item.Description,
                    Price = Convert.ToDecimal(request.Item.Price)
                };
                var addedItemId = await _inventoryRepository.AddItem(itemToBeAdded);
                return new AddItemResponse()
                {
                    AddedItemId = addedItemId
                };
            }
            catch (Exception ex)
            {
                return new AddItemResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }

        private static void Validate(AddItemRequest request)
        {
            if (request == null || request.Item == null ||
                string.IsNullOrEmpty(request.Item.Name) ||
                string.IsNullOrEmpty(request.Item.Name) ||
                string.IsNullOrEmpty(request.Item.Price) ||
                string.IsNullOrEmpty(request.Item.Description))
            {
                throw new Exception("Missing params in AddItemRequest !");
            }

            if (!decimal.TryParse(request.Item.Price, out _))
            {
                throw new Exception("Item price is not valid !");
            }
        }

        public async Task<RemoveItemResponse> RemoveItem(string itemId)
        {
            try
            {
                if (string.IsNullOrEmpty(itemId) || !int.TryParse(itemId, out _))
                {
                    throw new Exception("Item id is not valid !");
                }

                var result = await _inventoryRepository.RemoveItem(itemId);
                return result ? new RemoveItemResponse():
                new RemoveItemResponse()
                {
                    ErrorMessage = "The item with the specified id could not be removed!"
                };
            }
            catch (Exception ex)
            {
                return new RemoveItemResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
