using ItemsAPI.Data;
using ItemsAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemsAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DenshiContext denshiContext;

        public ItemRepository(DenshiContext denshiContext)
        {
            this.denshiContext = denshiContext;
        }

        public async Task AddAsync(Item item)
        {
            await this.denshiContext.AddAsync(item);

            await this.denshiContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await this.denshiContext.Set<Item>().ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsWithCategoryAsync()
        {
            return await this.denshiContext.Set<Item>().Include(x => x.Category).ToListAsync();
        }

        public async Task Remove(Item item)
        {
            this.denshiContext.ChangeTracker.Clear();

            this.denshiContext.Remove(item);

            await this.denshiContext.SaveChangesAsync();
        }

        public async Task Update(Item item)
        {
            this.denshiContext.ChangeTracker.Clear();

            this.denshiContext.Update(item);

            await this.denshiContext.SaveChangesAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await this.denshiContext.Set<Item>().FindAsync(id);
        }

    }
}
