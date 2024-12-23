namespace PersonSalariedEmployee
{
    public class Employee : Person
    {
        public double sal;
        public Employee(int Id, string FirstName, string LastName,double sal) : base(Id,FirstName,LastName)
        {
            //super(Id, FirstName, LastName);
            this.sal = sal;
        }
        public override double Salary()     //abstract method override in employee classs
        {
            return sal + 5000;
        }
    }
}