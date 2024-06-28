namespace BookHeaven.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string? Name { get; set; }

        // Relație 1:M cu Book
        public ICollection<Book>? Books { get; set; }
    }
}
