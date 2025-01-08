using Microsoft.EntityFrameworkCore;
using project.Models;
using Project.Dataaccess.Server;

namespace Project.Dataaccess.Repository
{
    public class CategoryRepo : ICategory
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Delete(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public async Task<List<Category>> GetCategory()
        {
            return await _db.Categories.ToListAsync(); ;
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            var category = await _db.Categories.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (category == null)
            {
                throw new Exception("Category is not present");
            }
            return category;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
