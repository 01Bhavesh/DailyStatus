namespace GenericsType
{
    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public Person(int id , string fname, string lname)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
        }
        public override string ToString()
        {
            return Fname + " " + Lname;
        }
    }
}