using CRUDoperationPractice.Model;
using CRUDoperationPractice.Server;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperationPractice.Service
{
    public class StudentService : IStudentService
    {
        private readonly DbData _db;
        public StudentService(DbData db)
        {
            _db = db;
        }
        public void Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Student student = _db.Students.FirstOrDefault(s => s.Id == Id);
            student.IsActive = false;
            _db.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> lst = _db.Students.ToList();
            return lst;
        }

        public void Update(Student student)
        {
            _db.Update(student);
            _db.SaveChanges();
        }
    }
}
