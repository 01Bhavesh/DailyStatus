using System;

namespace DiamondProblemSolution
{
    public class Salary : Employee, IVendar
    {
        public Salary(int Id) : base(Id)
        {
        }

        public void Name() {
            Console.WriteLine("Salary");
        }
    }
}