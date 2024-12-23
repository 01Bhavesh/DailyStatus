namespace ListMethods
{
    public class Person
    {
        public int Id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }

        public Person(int id , string fname , string lname)
        {
            Id = id;
            FName = fname;
            LName = lname;
        }
        public override string ToString()
        {
            return " " + FName + " " + LName;
        }
    }
}