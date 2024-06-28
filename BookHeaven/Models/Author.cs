namespace BookHeaven.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }

        // Relație M:M cu Book
        public ICollection<Book>? Books { get; set; }
       // public ICollection<BookAuthor>? BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
