namespace ShopBridge.Inventory.ApplicationContract
{
    public class GetItemByIdResponse: InventoryServiceResponse
    {
        public ItemDto Item { get; set; }
    }
}
