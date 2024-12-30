using EntityFramworkCode.Models;
using EntityFramworkCode.Server;
using Microsoft.EntityFrameworkCore;

namespace EntityFramworkCode.ServiceImplementation
{
    public class CategoryService : ICategoryService
    {
        private readonly DbProduct _dbProduct;
        public CategoryService(DbProduct dbProduct)
        {
            _dbProduct = dbProduct;
        }
        public async void AddCategory(Category category)
        {
            if (_dbProduct.categories.Any(p => p.CategoryName == category.CategoryName))
            {
                throw new Exception("This category name is already present");
            }
            await _dbProduct.categories.AddAsync(category);
            _dbProduct.categories.Find(category).isActive = true;
            _dbProduct.SaveChanges();
        }

        public void DeleteCategoryById(int Id)
        {
            Category p = (Category)_dbProduct.categories.Where(x => x.Id == Id);
            p.isActive = false;
            _dbProduct.categories.Remove(p);

        }


        public async Task<List<Category>> GetCategorie(int page, int pageSize)
        {
            return await _dbProduct.categories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Category > GetCategoryById(int Id)
        {
            Category p = await _dbProduct.categories.FindAsync(Id);
            if (p.Id == null)
            {
                throw new Exception("product is not present");
            }
            return p;
        }

        public void UpdateCategory(Category category)
        {
            _dbProduct.categories.Update(category);
            _dbProduct.SaveChanges();
        }
    }
}
