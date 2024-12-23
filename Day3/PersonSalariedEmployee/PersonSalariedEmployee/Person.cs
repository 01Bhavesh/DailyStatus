namespace PersonSalariedEmployee
{
    abstract public class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public Person(int Id , string FirstName, string LastName)
        {
            this.Id = Id;
            FName = FirstName;
            LName = LastName;
        }
        public string FullName()
        {
            string fullname = FName + " " + LName;
            return fullname;
        }
        abstract public double Salary();        //abstract method
    }
}