using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BookHeaven.Tests.Services
{
    public class BranchServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly Mock<IBranchRepository> _branchRepositoryMock = new Mock<IBranchRepository>();

        public BranchServiceTests()
        {
            _repositoryWrapperMock.Setup(rw => rw.BranchRepository).Returns(_branchRepositoryMock.Object);
        }

        [Fact]
        public async Task AddBranchAsync_ValidBranch_CallsAddAndSaveAsync()
        {
            // Arrange
            var branchToAdd = new Branch { /* proprietăți pentru un obiect de tip Branch */ };
            var branchService = new BranchService(_repositoryWrapperMock.Object);

            // Act
            await branchService.AddBranchAsync(branchToAdd);

            // Assert
            _branchRepositoryMock.Verify(repo => repo.AddAsync(branchToAdd), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBranchAsync_ValidBranch_CallsDeleteAndSaveAsync()
        {
            // Arrange
            var branchToDelete = new Branch { /* proprietăți pentru un obiect de tip Branch */ };
            var branchService = new BranchService(_repositoryWrapperMock.Object);

            // Act
            await branchService.DeleteBranchAsync(branchToDelete);

            // Assert
            _branchRepositoryMock.Verify(repo => repo.DeleteAsync(branchToDelete), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateBranchAsync_ValidBranch_CallsUpdateAndSaveAsync()
        {
            // Arrange
            var branchToUpdate = new Branch { /* proprietăți pentru un obiect de tip Branch */ };
            var branchService = new BranchService(_repositoryWrapperMock.Object);

            // Act
            await branchService.UpdateBranchAsync(branchToUpdate);

            // Assert
            _branchRepositoryMock.Verify(repo => repo.UpdateAsync(branchToUpdate), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }
    }
}
