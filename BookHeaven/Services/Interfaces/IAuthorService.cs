using BookHeaven.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHeaven.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAuthors();
        Task<Author?> GetAuthorByIdAsync(int id);
      //  Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId);
        Task<IEnumerable<Author>> GetAuthorsByIdsAsync(int[] ids);
        Task<Author?> GetAuthorByNameAsync(string name);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);


    }
}
