using System.Collections.Generic;

namespace LinqProgram
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public Book(int id , string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;

        }
        
    }
}