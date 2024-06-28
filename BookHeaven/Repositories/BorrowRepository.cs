using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;

namespace BookHeaven.Repositories
{
    public class BorrowRepository : RepositoryBase<Borrow>,IBorrowRepository
    {
        public BorrowRepository(BookHeavenContext context) : base(context) { }
    }
}
