using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            dynamic a = 10;  // datatype will be int
            a = "string";   //datatype will be string


            var books = new BookRepo().GetBooks();

            foreach (var book in books)
            {
                Console.WriteLine(book.Title + " " + book.Price);
            }

            var elements = books.Where(p => p.Price > 500).Select(p=>p.Title);
            //Console.WriteLine(elements);  //it will give referance
            foreach (var book in elements)
            {
                Console.WriteLine(book);
            }

            var element1 = books.Where(p => p.Price > 400).OrderBy(p=>p.Title).Select(p => p.Title);

            foreach (var book in element1)
            {
                Console.WriteLine(book);
            }
            var maxPrice = books.Max(p => p.Price);         //it will give value
            Console.WriteLine(maxPrice);

            var minprice = books.Where(p => p.Price == books.Min(q => q.Price)).Select(p => p.Title);
            //Console.WriteLine(minprice.ToString());    //it will give referance  
            foreach (var book in minprice)
            {
                Console.WriteLine(book);
            }


        }
    }
}
