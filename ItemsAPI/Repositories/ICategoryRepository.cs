using ItemsAPI.Data.Model;

namespace ItemsAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);
    }
}
