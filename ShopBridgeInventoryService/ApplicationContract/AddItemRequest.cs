using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Inventory.ApplicationContract
{
    public class AddItemRequest
    {
        public ItemDto Item { get; set; }
    }
}
