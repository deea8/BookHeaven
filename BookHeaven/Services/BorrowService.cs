using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookHeaven.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BorrowService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<Borrow> GetBorrowByIdAsync(int id)
        {
            return await _repositoryWrapper.BorrowRepository
                .FindByCondition(b => b.BorrowId == id)
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Borrow>> GetAllBorrowsAsync()
        {
            return await _repositoryWrapper.BorrowRepository
                .FindAll()
                .Include(b => b.Book)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Borrow> GetBorrowByBookAndUserAsync(int bookId, string userId)
        {
            return await _repositoryWrapper.BorrowRepository
                .FindByCondition(b => b.BookId == bookId && b.UserId == userId)
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync();
        }

        public async Task CreateBorrowAsync(Borrow borrow)
        {
            if (borrow == null)
            {
                throw new ArgumentNullException(nameof(borrow));
            }

            await _repositoryWrapper.BorrowRepository.AddAsync(borrow);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateBorrowAsync(Borrow borrow)
        {
            if (borrow == null)
            {
                throw new ArgumentNullException(nameof(borrow));
            }

            _repositoryWrapper.BorrowRepository.UpdateAsync(borrow);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<bool> BorrowExistsAsync(int id)
        {
            return await _repositoryWrapper.BorrowRepository
                .FindByCondition(b => b.BorrowId == id)
                .AnyAsync();
        }

        public async Task DeleteBorrowAsync(Borrow borrow)
        {
            if (borrow == null)
            {
                throw new ArgumentNullException(nameof(borrow));
            }

            _repositoryWrapper.BorrowRepository.DeleteAsync(borrow);
            await _repositoryWrapper.SaveAsync();
        }

       
    }
}
