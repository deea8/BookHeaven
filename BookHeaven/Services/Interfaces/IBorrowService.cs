using BookHeaven.Models;
using System.Linq.Expressions;

namespace BookHeaven.Services.Interfaces
{
    public interface IBorrowService
    {
        Task<Borrow> GetBorrowByIdAsync(int id);
        Task<IEnumerable<Borrow>> GetAllBorrowsAsync();
        Task CreateBorrowAsync(Borrow borrow);
        Task UpdateBorrowAsync(Borrow borrow);
        Task<bool> BorrowExistsAsync(int id);
        Task DeleteBorrowAsync(Borrow borrow);
        Task<Borrow> GetBorrowByBookAndUserAsync(int bookId, string userId);
    }
}
