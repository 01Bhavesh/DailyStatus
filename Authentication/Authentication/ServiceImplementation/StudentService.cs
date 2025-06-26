using Authentication.IServiceImplementation;
using Authentication.Model;
using Authentication.Server;

namespace Authentication.ServiceImplementation
{
    public class StudentService : IStudentService
    {
        private readonly DbServer _dbServer;
        public StudentService(DbServer db)
        {
            _dbServer = db;
        }

        public bool Create(Student student)
        {
            Student std = _dbServer.Students.FirstOrDefault(s => s.FirstName == student.FirstName && s.Password == student.Password);
            if (std != null)
            {
                return false;
            }
            _dbServer.Students.Add(student);
            _dbServer.SaveChanges();
            return true;
        }

        public void Delete(int Id)
        {
            Student std = _dbServer.Students.FirstOrDefault(s => s.Id == Id);
            std.IsActive = false;
            _dbServer.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> lst = _dbServer.Students.Where(s => s.IsActive).ToList();
            return lst;
        }

        public Student GetById(int Id)
        {
            return _dbServer.Students.FirstOrDefault(s => s.Id == Id);
        }

        public void Update(Student student)
        {
            _dbServer.Students.Update(student);
            _dbServer.SaveChanges();
        }
    }
}
