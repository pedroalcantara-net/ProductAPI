using System.ComponentModel.DataAnnotations;

namespace Products.Domain.ViewModel
{
    public class ProductViewModel
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
