using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookHeaven.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BookService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _repositoryWrapper.BookRepository.FindAll().Include(book => book.Publisher).Include(book => book.Author).ToListAsync();
        }

        public async Task<List<Book>> SearchBooksByTitleAsync(string searchTerm)
        {
            return await _repositoryWrapper.BookRepository.FindByCondition(b => b.Title.Contains(searchTerm))
                .Include(b => b.Publisher)
                .Include(ba => ba.Author)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByConditionAsync(Expression<Func<Book, bool>> expression)
        {
            return await _repositoryWrapper.BookRepository.FindByCondition(expression).ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _repositoryWrapper.BookRepository.FindByCondition(book => book.BookId == id).Include(book => book.Publisher).FirstOrDefaultAsync();
        }

        public async Task<string?> GetPublisherNameForBookAsync(int bookId)
        {
            var book = await _repositoryWrapper.BookRepository.FindByCondition(b => b.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                var publisher = await _repositoryWrapper.PublisherRepository.FindByCondition(p => p.PublisherId == book.PublisherId).FirstOrDefaultAsync();
                return publisher?.Name; // Returnează numele editurii sau null dacă nu este găsită
            }
            return null; // Sau o valoare implicită corespunzătoare
        }

        public async Task<string?> GetAuthorNameForBookAsync(int bookId)
        {
            var book = await _repositoryWrapper.BookRepository.FindByCondition(b => b.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                var publisher = await _repositoryWrapper.AuthorRepository.FindByCondition(p => p.AuthorId == book.AuthorId).FirstOrDefaultAsync();
                return publisher?.Name; // Returnează numele editurii sau null dacă nu este găsită
            }
            return null; // Sau o valoare implicită corespunzătoare
        }



        public async Task AddBookAsync(Book book)
        {
            await _repositoryWrapper.BookRepository.AddAsync(book);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _repositoryWrapper.BookRepository.UpdateAsync(book);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            await _repositoryWrapper.BookRepository.DeleteAsync(book);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<bool> BookExistsAsync(int bookId)
        {
            var book = await _repositoryWrapper.BookRepository.FindByCondition(b => b.BookId == bookId).FirstOrDefaultAsync();
            return book != null;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _repositoryWrapper.BookRepository.FindAll()
                .Include(b => b.Publisher)
                .Include(ba => ba.Author)
                .ToListAsync();
        }

        public Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
