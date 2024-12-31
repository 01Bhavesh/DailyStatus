using EntityFramworkCode.Models;

namespace EntityFramworkCode.ServiceImplementation
{
    public interface ICategoryService
    {
        public Task<(List<Category> categories, int totalcount)> GetCategorie(int page, int pageSize);
        public Task<Category> GetCategoryById(int Id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategoryById(int Id);
    }
}
