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
        public void AddCategory(Category category)
        {
            if (_dbProduct.categories.Any(p => p.CategoryName == category.CategoryName))
            {
                throw new Exception("This category name is already present");
            }
            category.isActive = true;
            _dbProduct.categories.Add(category);
            _dbProduct.SaveChanges();
        }

        public void DeleteCategoryById(int Id)
        {
            var p = _dbProduct.categories.Find(Id);
            p.isActive = false;
            var prod = _dbProduct.products.Where( p => p.CategoryId == Id);
            foreach (var pr in prod) //check 
            {
                pr.isActive = false;
            }
            
            _dbProduct.SaveChanges();
        }


        public async Task<(List<Category> categories, int totalcount)> GetCategorie(int page, int pageSize)  //Lazy Loading
        {
            int totalcount =  _dbProduct.categories.Count();
            return (await _dbProduct
                .categories
                //.Where(c => c.isActive == true)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(c => c.CategoryId)
                .ToListAsync() , totalcount);
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            var p = await _dbProduct
                .categories
                .FirstOrDefaultAsync(c => c.CategoryId == Id);
            if (p == null)
            {
                throw new Exception("product is not present");
            }
            return p;
        }

        public void UpdateCategory(Category category)
        {
            if (category.isActive == true)
            {
                var prop = _dbProduct.products.Where(p => p.CategoryId == category.CategoryId);
                foreach (var p in prop)
                {
                    p.isActive = true;
                }
            }
            if (category.isActive == false)
            {
                var prop = _dbProduct.products.Where(p => p.CategoryId == category.CategoryId);
                foreach (var p in prop)
                {
                    p.isActive = false;
                }
            }

            _dbProduct.categories.Update(category);
            _dbProduct.SaveChanges();
        }
    }
}
