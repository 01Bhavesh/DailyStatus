using System;

namespace DiamondProblemSolution
{
    public class Vendar : Person , IVendar
    {



        public Vendar(int Id )
        {
            this.Id = Id;
        }

        public void Name()
        {
            Console.WriteLine("Vender"); 
        }
    }
}