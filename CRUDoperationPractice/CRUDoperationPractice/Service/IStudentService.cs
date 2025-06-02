using CRUDoperationPractice.Model;

namespace CRUDoperationPractice.Service
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public void Create(Student student);
        public void Update(Student student);
        public void Delete(int Id);
    }
}
