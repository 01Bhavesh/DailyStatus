namespace Monday01
{
    public class Person
    {
        private int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Field { get; set; }
        public Person(int Id , string FName , string LName)    // Use to initailize data members / properties values
        {
            this.Id = Id;
            FirstName = FName;
            LastName = LName;
        }

        public Person(string Field)              // Method overloading / complie time polymorphisam
        {                                       // increase readability
            this.Field = Field;  
        }

        public double PlayerSalary()                  //parameterless method which showing player salary
        {
            return 50000;
        }
        public double PlayerSalary(int IPL)           //parameterize method which include IPL salary
        {
            return 50000 + IPL;
        }

    }
}