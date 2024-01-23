using System.ComponentModel.DataAnnotations;

namespace ItemsAPI.Data.Model
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string? Name{ get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
