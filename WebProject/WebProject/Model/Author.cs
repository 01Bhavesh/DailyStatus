namespace WebProject.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public IList<Book> Book { get; set; }

    }
}