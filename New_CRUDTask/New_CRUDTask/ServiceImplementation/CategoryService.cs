using Microsoft.EntityFrameworkCore;
using New_CRUDTask.ExceptionHandling;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Server;

namespace New_CRUDTask.ServiceImplementation
{
    public class CategoryService : ICategoryService
    {
        private readonly DbContextServer _db;
        public CategoryService(DbContextServer db)
        {
            _db = db;
        }
        public void AddCategory(Category category)
        {
            if (_db.Categories.Any(c => c.Name == category.Name))
            {
                throw new TaskException("Category is already exists.");
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category? c = GetCategoryById(id);
            c.IsActive = false;
            _db.SaveChanges();
        }

        public async Task<(List<Category>, int totalcount)> GetCategory(int page, int pageSize)
        {
            int totalcount = _db.Categories.Count();
            return (await _db
                .Categories
                .Where(c => c.IsActive == true)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(c => c.CategoryId)
                .ToListAsync(), totalcount);
        }

        public Category? GetCategoryById(int? id)
        {
            Category? c = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return c;
        }

        public void ReNewExitingCategory(Category category)
        {
            if (category == null)
            {
                throw new TaskException("Category cannot be null.");
            }
            Category? c = _db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (c == null)
            {
                throw new TaskException("Category cannot be null.");
            }
            UpdateCategory(category);

        }

        public void UpdateCategory(Category Category)
        {
            if (Category.IsActive != true)
            {
                throw new TaskException("Category is already exists.");
            }
            _db.Categories.Update(Category);
            _db.SaveChanges();
        }
    }
}
