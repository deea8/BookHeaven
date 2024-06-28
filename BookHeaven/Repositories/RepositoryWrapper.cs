using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services;
using BookHeaven.Services.Interfaces;

namespace BookHeaven.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly BookHeavenContext _context;
        private IPublisherRepository _publisherRepository;
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IAuthorRepository _authorRepository;
        private IBorrowRepository _borrowRepository;
        private IBranchRepository _branchRepository;
        
      
        public RepositoryWrapper(BookHeavenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IPublisherRepository PublisherRepository => _publisherRepository ??= new PublisherRepository(_context);
        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_context);
        public IBorrowRepository BorrowRepository => _borrowRepository ??= new BorrowRepository(_context);
        public IBranchRepository BranchRepository => _branchRepository ??= new BranchRepository(_context);

       
       

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
