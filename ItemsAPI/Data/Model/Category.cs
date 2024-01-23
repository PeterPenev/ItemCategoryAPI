using System.ComponentModel.DataAnnotations;

namespace ItemsAPI.Data.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
