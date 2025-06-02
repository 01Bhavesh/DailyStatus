using System.ComponentModel.DataAnnotations;

namespace CRUDoperation.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Range(1,10000)]
        public int Price { get; set; }
        public bool IsActive { get; set; }
    }
}
