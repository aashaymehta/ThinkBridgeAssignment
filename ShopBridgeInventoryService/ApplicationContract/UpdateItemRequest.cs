namespace ShopBridge.Inventory.ApplicationContract
{
    public class UpdateItemRequest : InventoryServiceResponse
    {
        public ItemDto Item { get; set; }
    }
}
