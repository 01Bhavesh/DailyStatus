
namespace EmployeeFiles
{
    public class Employee : Person
    {
        public int Id { get; set; }
        private double salary { get; set; }      // property name should be different than accessing method
        public Employee(int id, string name, string address, int _id, double salary) : base(id, name, address)
        {
            this.Id = id;
            this.salary = salary;
        }
        public double Salary        //gettter-setter method name is different than property name
        {
            get { return salary; }
            set { this.salary = salary; }
        }
        public virtual double Insentive()
        {
            return (salary * 0.05) + 5000;
        }

        public override double Income()
        {
            return salary;
        }
    }
}