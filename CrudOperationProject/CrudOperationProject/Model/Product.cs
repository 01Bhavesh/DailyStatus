namespace CrudOperationProject.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category? CategoryName { get; set; }
    }
}
