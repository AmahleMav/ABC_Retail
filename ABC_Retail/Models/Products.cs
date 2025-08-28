using System.ComponentModel.DataAnnotations;

namespace ABC_Retail.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; } 
    }
}
