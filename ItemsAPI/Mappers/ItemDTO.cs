using ItemsAPI.Data.Model;
using ItemsAPI.DTOs;

namespace ItemsAPI.Mappers
{
    static class ItemDTOMapper
    {
        public static ItemDTO ToDTO(this Item entity)
        {
            if (entity is null)
            {
                return null;
            }

            var dto = new ItemDTO()
            {
                Id = entity.ID,
                Name = entity.Name,
                Category = entity.Category?.Name,
            };

            return dto;
        }
    }
}
