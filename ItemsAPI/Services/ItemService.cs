using ItemsAPI.Data.Model;
using ItemsAPI.DTOs;
using ItemsAPI.Mappers;
using ItemsAPI.Repositories;

namespace ItemsAPI.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly ICategoryRepository categoryRepository;

        public ItemService(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            this.itemRepository = itemRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<string> CreateItemAsync(Item item)
        {
            bool isItemValid = await this.IsItemValid(item);

            if (!isItemValid)
            {
                throw new Exception($"(Entry with name {item.Name} was not valid and was not created)");
            }

            var itemToInstert = new Item
            {
                Name = item.Name,
                CategoryId = item.CategoryId
            };

            try
            {
                await this.itemRepository.AddAsync(itemToInstert);
            }
            catch (Exception ex)
            {
                throw new Exception($"Item with name {itemToInstert.Name} was not created! Please check for more detaails: {ex.Message}");
            }

            return $"Item with name {itemToInstert.Name} was created successfully!";
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            var items = await this.itemRepository.GetAllItemsAsync();

            return items;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsWithCategoryNameAsync()
        {
            var items = await this.itemRepository.GetAllItemsWithCategoryAsync();

            var itemDTOs = items.Select(i => i.ToDTO()).ToList();

            return itemDTOs;
        }

        public async Task<Item> UpdateItemAsync(Item itemWithNewData)
        {
            var isItemForUpdateExisting = await this.itemRepository.GetByIdAsync(itemWithNewData.ID);

            if (isItemForUpdateExisting == null)
            {
                throw new Exception($"Update of item with name {itemWithNewData.Name} and id {itemWithNewData.ID} doesn't exists!");
            }

            bool isItemValid = await this.IsItemValid(itemWithNewData);

            if (!isItemValid)
            {
                throw new Exception($"(Entry with name {itemWithNewData.Name} was not valid and was not created)");
            }

            try
            {
                await this.itemRepository.Update(itemWithNewData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Update of item with name {itemWithNewData.Name} is not possible. For more details please see {ex.Message}");
            }

            return itemWithNewData;
        }

        public async Task<Item> DeleteItemAsync(Item itemForDelete)
        {
            var isItemForDeleteExisting = await this.itemRepository.GetByIdAsync(itemForDelete.ID);

            if (isItemForDeleteExisting == null)
            {
                throw new Exception($"(Item with name {itemForDelete.Name} and id {itemForDelete.ID} doesn't exists!");
            }           

            try
            {
                await this.itemRepository.Remove(itemForDelete);
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete of item with Name {itemForDelete.Name} with ID {itemForDelete.ID} is not possible. For more details please see {ex.Message}");
            }

            return isItemForDeleteExisting;
        }


        private async Task<bool> IsItemValid(Item item)
        {
            if (string.IsNullOrEmpty(item.Name) || item.Name.Length >=100)
            {
                return false;
            }

            var isCategoryExisting = await this.categoryRepository.GetByIdAsync(item.CategoryId);

            if (isCategoryExisting == null) 
            {
                return false;
            }

            return true;
        }
    }
}
