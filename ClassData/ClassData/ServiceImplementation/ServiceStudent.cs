using ClassData.IServiceImplemetation;
using ClassData.Model;
using ClassData.Server;

namespace ClassData.ServiceImplementation
{
    public class ServiceStudent : IStudent
    {
        private readonly DbConn _conn;
        public ServiceStudent(DbConn conn)
        {
            _conn = conn;
        }
        public void Add(Student student)
        {
            _conn.students.Add(student);
            _conn.SaveChanges();
        }

        public void Delete(int id)
        {
            Student std = _conn.students.FirstOrDefault(s => s.Id == id);
            std.IsActive = false;
            _conn.SaveChanges();
        }

        public List<Student> GetAll()
        {
             List<Student> lst = _conn.students.Where(s => s.IsActive).ToList(); //IEnumerable
            //var lst = _conn.students.Where(s => s.IsActive); //IQureyable
            return lst;
        }

        public Student GetById(int id)
        {
            Student std = _conn.students.FirstOrDefault(s => s.Id == id);
            return std;
        }

        public void Update(Student student)
        {
            _conn.students.Update(student);
            _conn.SaveChanges();
        }
    }
}
