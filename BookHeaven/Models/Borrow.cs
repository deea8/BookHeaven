namespace BookHeaven.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
