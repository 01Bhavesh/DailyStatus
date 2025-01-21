using ProductCategoryStoreProcedure.Models;

namespace ProductCategoryStoreProcedure.Server
{
    public interface ICategoryStoreProcedure
    {
        public IList<Category> AllCategories();

        public void CreateCategory(Category category);
    }
}
