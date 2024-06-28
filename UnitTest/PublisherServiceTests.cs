using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace BookHeaven.Tests.Services
{
    public class PublisherServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly Mock<IPublisherRepository> _publisherRepositoryMock = new Mock<IPublisherRepository>();

        public PublisherServiceTests()
        {
            _repositoryWrapperMock.Setup(rw => rw.PublisherRepository).Returns(_publisherRepositoryMock.Object);
        }

        [Fact]
        public async Task AddPublisherAsync_ValidPublisher_CallsAddAndSaveAsync()
        {
            // Arrange
            var publisherToAdd = new Publisher { /* proprietăți pentru un obiect de tip Publisher */ };
            var publisherService = new PublisherService(_repositoryWrapperMock.Object);

            // Act
            await publisherService.AddPublisherAsync(publisherToAdd);

            // Assert
            _publisherRepositoryMock.Verify(repo => repo.AddAsync(publisherToAdd), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeletePublisherAsync_ValidPublisher_CallsDeleteAndSaveAsync()
        {
            // Arrange
            var publisherToDelete = new Publisher { /* proprietăți pentru un obiect de tip Publisher */ };
            var publisherService = new PublisherService(_repositoryWrapperMock.Object);

            // Act
            await publisherService.DeletePublisherAsync(publisherToDelete);

            // Assert
            _publisherRepositoryMock.Verify(repo => repo.DeleteAsync(publisherToDelete), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdatePublisherAsync_ValidPublisher_CallsUpdateAndSaveAsync()
        {
            // Arrange
            var publisherToUpdate = new Publisher { /* proprietăți pentru un obiect de tip Publisher */ };
            var publisherService = new PublisherService(_repositoryWrapperMock.Object);

            // Act
            await publisherService.UpdatePublisherAsync(publisherToUpdate);

            // Assert
            _publisherRepositoryMock.Verify(repo => repo.UpdateAsync(publisherToUpdate), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

       
    }
}
