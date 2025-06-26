using Authentication.Model;

namespace Authentication.IServiceImplementation
{
    public interface IStudentService
    {
        public bool Create(Student student);
        public List<Student> GetAll();
        public void Update(Student student);
        public void Delete(int Id);
        public Student GetById(int Id);
    }
}
