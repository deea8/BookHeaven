using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;

namespace BookHeaven.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookHeavenContext context) : base(context)
        {
        }
    }
}
