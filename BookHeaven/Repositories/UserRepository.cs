using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;

namespace BookHeaven.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(BookHeavenContext context) : base(context) { }
    }
}
