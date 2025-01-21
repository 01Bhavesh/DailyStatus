using Microsoft.EntityFrameworkCore;
using ProductCategoryStoreProcedure.Models;

namespace ProductCategoryStoreProcedure.Server
{
    public class CategoryStoreProcedure : ICategoryStoreProcedure
    {
        private readonly DbCategory _db;
        public CategoryStoreProcedure(DbCategory db)
        {
            _db = db;
        }
        public IList<Category> AllCategories()
        {
            return _db.Categories
                .FromSqlRaw<Category>("GetAllCategory")
                .ToList();
        }

        public void CreateCategory(Category category)
        {
            //_db.Categories.ExecuteSqlRaw("CreateCategory {0}", category.CategoryName);
        }
    }
}
