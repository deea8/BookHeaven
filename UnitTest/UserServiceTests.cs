using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookHeaven.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

        public UserServiceTests()
        {
            _repositoryWrapperMock.Setup(rw => rw.UserRepository).Returns(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task AddUserAsync_ValidUser_CallsAddAndSaveAsync()
        {
            var userService = new UserService(_repositoryWrapperMock.Object);
            var userToAdd = new User();

            await userService.AddUserAsync(userToAdd);

            _userRepositoryMock.Verify(repo => repo.AddAsync(userToAdd), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ValidUser_CallsDeleteAndSaveAsync()
        {
            var userService = new UserService(_repositoryWrapperMock.Object);
            var userToDelete = new User();

            await userService.DeleteUserAsync(userToDelete);

            _userRepositoryMock.Verify(repo => repo.DeleteAsync(userToDelete), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ValidUser_CallsUpdateAndSaveAsync()
        {
            var userService = new UserService(_repositoryWrapperMock.Object);
            var userToUpdate = new User();

            await userService.UpdateUserAsync(userToUpdate);

            _userRepositoryMock.Verify(repo => repo.UpdateAsync(userToUpdate), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

      
    }
}
