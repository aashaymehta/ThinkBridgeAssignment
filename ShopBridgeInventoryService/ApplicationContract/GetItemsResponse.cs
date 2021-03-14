using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Inventory.ApplicationContract
{
    public class GetItemsResponse: InventoryServiceResponse
    {
        public List<ItemDto> Items { get; set; }
    }
}
