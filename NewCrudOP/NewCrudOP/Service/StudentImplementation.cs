using NewCrudOP.DbServer;
using NewCrudOP.IService;
using NewCrudOP.Model;

namespace NewCrudOP.Service
{
    public class StudentImplementation : IStudent
    {
        private readonly DbConnect _db;
        public StudentImplementation(DbConnect Db)
        {
            _db = Db;
        }
        public void Add(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Student student = _db.Students.FirstOrDefault(x => x.Id == Id);
            student.IsActive = false;
            _db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> std = _db.Students.Where(s => s.IsActive).ToList();
            return std;
        }

        public void Update(Student student)
        {
            _db.Students.Update(student);
            _db.SaveChanges();
        }
    }
}
