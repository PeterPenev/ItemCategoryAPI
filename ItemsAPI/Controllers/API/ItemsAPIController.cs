using ItemsAPI.Data.Model;
using ItemsAPI.DTOs;
using ItemsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemsAPI.Controllers.API
{
    [Route("api/")]
    [ApiController]
    public class ItemsAPIController : Controller
    {
        private readonly IItemService itemService;

        public ItemsAPIController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var result = await this.itemService.CreateItemAsync(item);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllItems")]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var result = await this.itemService.GetAllItemsAsync();

            return result;
        }

        [HttpGet]
        [Route("GetAllItemsWithCategory")]
        public async Task<IEnumerable<ItemDTO>> GetAllItemsWithCategory()
        {
            var result = await this.itemService.GetAllItemsWithCategoryNameAsync();

            return result;
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var updatedItem = await this.itemService.UpdateItemAsync(item);

            return Ok(updatedItem);
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public async Task<IActionResult> DeleteItem([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var deletedItem = await this.itemService.DeleteItemAsync(item);

            return Ok(deletedItem);
        }
    }
}
