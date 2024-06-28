namespace BookHeaven.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } 
        
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

    }

}
