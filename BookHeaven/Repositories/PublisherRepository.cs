using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;

namespace BookHeaven.Repositories
{
    public class PublisherRepository:RepositoryBase<Publisher>,IPublisherRepository
    {
        public PublisherRepository(BookHeavenContext context) : base(context) { }
    }
}
