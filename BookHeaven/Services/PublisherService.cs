using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BookHeaven.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PublisherService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
           await _repositoryWrapper.PublisherRepository.AddAsync(publisher);
           await _repositoryWrapper.SaveAsync();
        }

        public async Task DeletePublisherAsync(Publisher publisher)
        {
            await _repositoryWrapper.PublisherRepository.DeleteAsync(publisher);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            await _repositoryWrapper.PublisherRepository.UpdateAsync(publisher);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<List<Publisher>> GetPublishers()
        {
            return await _repositoryWrapper.PublisherRepository.FindAll().ToListAsync();
        }
        
    }
}
