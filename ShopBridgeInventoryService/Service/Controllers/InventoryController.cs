using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Inventory.ApplicationContract;

namespace ShopBridge.Inventory.Service.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryApplication _inventoryApplication;

        public InventoryController(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllItems()
        {
           var result = await _inventoryApplication.GetAllItems().ConfigureAwait(false);
           return BuildResponse(result);
        }

        [HttpGet]
        [Route("item/{itemId}")]
        public async Task<IActionResult> GetItemById(string itemId)
        {
            var result = await _inventoryApplication.GetItemById(itemId).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
        {
            var result = await _inventoryApplication.AddItem(request).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpPost]
        [Route("updateItem")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequest request)
        {
            var result = await _inventoryApplication.UpdateItem(request).ConfigureAwait(false);
            return BuildResponse(result);
        }

        [HttpDelete]
        [Route("removeItem")]
        public async Task<IActionResult> RemoveItem(string itemId)
        {
            var result = await _inventoryApplication.RemoveItem(itemId).ConfigureAwait(false);
            return BuildResponse(result);
        }

        private ActionResult BuildResponse(InventoryServiceResponse response)
        {
            return new JsonResult(response);
        }
    }
}
