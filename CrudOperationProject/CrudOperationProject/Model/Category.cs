namespace CrudOperationProject.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public bool isActive { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
