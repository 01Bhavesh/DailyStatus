using NewCrudOP.Model;

namespace NewCrudOP.IService
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public void Add(Student student);
        public void Update(Student student);    
        public void Delete(int Id);
            
    }
}
