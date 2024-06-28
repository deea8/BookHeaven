using BookHeaven.Models;
using System.Linq.Expressions;

namespace BookHeaven.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<List<Book>> GetBooksByConditionAsync(Expression<Func<Book, bool>> expression);
        Task<Book?> GetBookByIdAsync(int id);
        Task<string?> GetPublisherNameForBookAsync(int bookId);
        Task<string?> GetAuthorNameForBookAsync(int bookId);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<bool> BookExistsAsync(int bookId);
        Task<List<Book>> SearchBooksByTitleAsync(string searchTerm);

    }
}
