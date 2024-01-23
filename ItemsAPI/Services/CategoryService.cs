using ItemsAPI.Data.Model;
using ItemsAPI.Repositories;

namespace ItemsAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<string> CreateCategoryAsync(Category category)
        {
            bool isCategoryValid = this.IsCategoryValid(category);

            if (!isCategoryValid)
            {
                throw new Exception($"(Entry with name {category.Name} was not valid and was not created)");
            }

            var categoryToInstert = new Category
            {
                Name = category.Name
            };

            try
            {
                await this.categoryRepository.AddAsync(categoryToInstert);
            }
            catch (Exception ex)
            {
                throw new Exception($"Category with name {categoryToInstert.Name} was not created! Please check for more detaails: {ex.Message}");
            }

            return $"Category with name {categoryToInstert.Name} was created successfully!";
        }        

        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            var categories = await this.categoryRepository.GetAllAsync();

            var categoriesNames = categories.Select(c=> c.Name).ToList();

            return categoriesNames;
        }

        private bool IsCategoryValid(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                return false;
            }

            return true;
        }
    }
}
