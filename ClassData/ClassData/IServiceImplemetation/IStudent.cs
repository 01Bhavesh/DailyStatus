using ClassData.Model;

namespace ClassData.IServiceImplemetation
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public void Add(Student student);
        public void Update(Student student);
        public void Delete(int id);
        public Student GetById(int id);

    }
}
