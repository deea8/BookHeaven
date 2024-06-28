using BookHeaven.Models;

namespace BookHeaven.Services.Interfaces
{
    public interface IPublisherService
    {
        Task <List<Publisher>> GetPublishers();
        Task AddPublisherAsync(Publisher publisher);
        Task UpdatePublisherAsync(Publisher publisher);
        Task DeletePublisherAsync(Publisher publisher);
    }
}
