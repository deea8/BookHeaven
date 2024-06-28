namespace BookHeaven.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IPublisherRepository PublisherRepository { get; }
        IBookRepository BookRepository { get; }
        IUserRepository UserRepository { get; }
        IBorrowRepository BorrowRepository { get; }
        IBranchRepository BranchRepository { get; }
        IAuthorRepository AuthorRepository { get; }
      
        Task SaveAsync();
    }
}