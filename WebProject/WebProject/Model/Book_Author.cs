using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    public class Book_Author
    {
        public int Book_AuthorId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Authors { get; set; }
    }
}
