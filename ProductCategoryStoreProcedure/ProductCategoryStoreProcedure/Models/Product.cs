using System.ComponentModel.DataAnnotations;

namespace ProductCategoryStoreProcedure.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Category Category { get; set; }
    }
}
