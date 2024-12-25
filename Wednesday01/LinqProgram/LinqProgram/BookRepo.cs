using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProgram
{
    public class BookRepo
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book> {
                new Book(1,"Naruto",500),
                new Book(2,"FM",400),
                new Book(3,"Haikyuu",600),
                new Book(4,"Relive",300)

                };
        }
    }
}
