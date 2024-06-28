using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;

namespace BookHeaven.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>,IBranchRepository
    {
        public BranchRepository(BookHeavenContext context) : base(context) { }
    }
}
