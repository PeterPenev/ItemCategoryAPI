using ItemsAPI.Data.Model;

namespace ItemsAPI.Repositories
{
    public interface IItemRepository
    {
        Task AddAsync(Item item);

        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<IEnumerable<Item>> GetAllItemsWithCategoryAsync();

        Task Remove(Item item);

        Task Update(Item item);

        Task<Item> GetByIdAsync(int id);
    }
}
