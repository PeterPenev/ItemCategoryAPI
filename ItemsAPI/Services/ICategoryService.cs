using ItemsAPI.Data.Model;

namespace ItemsAPI.Services
{
    public interface ICategoryService
    {
        Task<string> CreateCategoryAsync(Category category);

        Task<IEnumerable<string>> GetAllCategoriesAsync();
    }
}
