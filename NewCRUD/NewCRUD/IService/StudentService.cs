using NewCRUD.Model;
using NewCRUD.Server;

namespace NewCRUD.IService
{
    public class StudentService : IStudentService
    {
        private readonly DBStudent _Db;
        public StudentService(DBStudent db)
        {
            _Db = db;
        }
        public void Add(Student student)
        {
            _Db.Students.Add(student);
            _Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student std = _Db.Students.FirstOrDefault(s => s.Id ==id);
            _Db.Students.Remove(std);
            _Db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> lst = _Db.Students.ToList();
            return lst;
        }

        public Student GetById(int id)
        {
            Student std = _Db.Students.FirstOrDefault(s => s.Id == id);
            return std;
        }

        public void Update(Student student)
        {
            _Db.Students.Update(student);
            _Db.SaveChanges();
        }
    }
}
