namespace EmployeeFiles
{
    abstract public class Person
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        public Person(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
        public abstract double Income();
        //public virtual double Insentive(double sal)
        //{
        //    return 5000;
        //}
    }
}

