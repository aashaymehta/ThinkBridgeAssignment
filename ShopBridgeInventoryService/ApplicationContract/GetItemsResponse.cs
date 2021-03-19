using System.Collections.Generic;

namespace ShopBridge.Inventory.ApplicationContract
{
    public class GetItemsResponse: InventoryServiceResponse
    {
        public List<ItemDto> Items { get; set; }
    }
}
