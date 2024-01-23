using ItemsAPI.Data.Model;
using ItemsAPI.DTOs;

namespace ItemsAPI.Services
{
    public interface IItemService
    {
        Task<string> CreateItemAsync(Item item);

        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<IEnumerable<ItemDTO>> GetAllItemsWithCategoryNameAsync();

        Task<Item> UpdateItemAsync(Item itemWithNewData);

        Task<Item> DeleteItemAsync(Item itemForDelete);
    }
}
