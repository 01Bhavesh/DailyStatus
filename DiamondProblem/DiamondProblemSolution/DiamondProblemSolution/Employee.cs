using System;

namespace DiamondProblemSolution
{
    public class Employee : Person ,IEmployee
    {
        
        public int Id { get; set; }
       
        public Employee(int Id)
        {
            this.Id = Id;
        }

        public void Name()
        {
            Console.WriteLine("Employee"); ;
        }
    }
}