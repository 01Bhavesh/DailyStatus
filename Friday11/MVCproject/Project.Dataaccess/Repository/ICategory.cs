using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Models;

namespace Project.Dataaccess.Repository
{
    public interface ICategory
    {
        public Task<List<Category>> GetCategory();
        public Task<Category> GetCategoryById(int Id);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(Category category);

    }
}
