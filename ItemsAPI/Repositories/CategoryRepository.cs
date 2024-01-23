using ItemsAPI.Data;
using ItemsAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemsAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DenshiContext denshiContext;

        public CategoryRepository(DenshiContext denshiContext)
        {
            this.denshiContext = denshiContext;
        }

        public async Task AddAsync(Category category)
        {
            await this.denshiContext.AddAsync(category);

            await this.denshiContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.denshiContext.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await this.denshiContext.Set<Category>().FindAsync(id);
        }
    }
}
