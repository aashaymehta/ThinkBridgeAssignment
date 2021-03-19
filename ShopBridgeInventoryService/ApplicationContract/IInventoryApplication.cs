using System.Threading.Tasks;

namespace ShopBridge.Inventory.ApplicationContract
{
    public interface IInventoryApplication
    {
        Task<GetItemsResponse> GetAllItems();

        Task<GetItemByIdResponse> GetItemById(string itemId);

        Task<AddItemResponse> AddItem(AddItemRequest request);

        Task<RemoveItemResponse> RemoveItem(string itemId);
    }
}
