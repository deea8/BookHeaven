using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Repositories
{

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookHeavenContext context) : base(context) { }
    }
}
