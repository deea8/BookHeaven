using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services;
using BookHeaven.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace BookHeaven.Tests.Services
{
    public class AuthorServiceTests
    {
        private IAuthorService authorService;
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly Mock<IAuthorRepository> _authorRepositoryMock = new Mock<IAuthorRepository>();

        public AuthorServiceTests()
        {
            _repositoryWrapperMock.Setup(rw => rw.AuthorRepository).Returns(_authorRepositoryMock.Object);
            authorService = new AuthorService(_repositoryWrapperMock.Object);
        }

       

        [Fact]
        public async Task AddAuthorAsync_CallsAddAndSave_WhenAuthorIsValid()
        {
            // Arrange
            var author = new Author { AuthorId = 1, Name = "John Doe" };

            // Act
            await authorService.AddAuthorAsync(author);

            // Assert
            _authorRepositoryMock.Verify(repo => repo.AddAsync(author), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAuthorAsync_CallsDeleteAndSave_WhenAuthorIsValid()
        {
            // Arrange
            var author = new Author { AuthorId = 1, Name = "John Doe" };

            // Act
            await authorService.DeleteAuthorAsync(author);

            // Assert
            _authorRepositoryMock.Verify(repo => repo.DeleteAsync(author), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        //[Fact]
        //public async Task GetAuthors_ReturnsAllAuthors()
        //{
        //    // Arrange
        //    var authors = new List<Author>
        //    {
        //        new Author { AuthorId = 1, Name = "John Doe" },
        //        new Author { AuthorId = 2, Name = "Jane Smith" }
        //    }.AsQueryable();

        //    _authorRepositoryMock.Setup(repo => repo.FindAll()).Returns(authors);

        //    // Act
        //    var result = await authorService.GetAuthors();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(2, result.Count);
        //}

        //[Fact]
        //public async Task GetAuthorByIdAsync_ReturnsAuthor_WhenAuthorExists()
        //{
        //    // Arrange
        //    var authorId = 1;
        //    var author = new Author { AuthorId = authorId, Name = "John Doe" };
        //    var authors = new List<Author> { author }.AsQueryable();

        //    _authorRepositoryMock
        //        .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Author, bool>>>()))
        //        .Returns(authors);

        //    // Act
        //    var result = await authorService.GetAuthorByIdAsync(authorId);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(authorId, result.AuthorId);
        //}

        [Fact]
        public async Task UpdateAuthorAsync_CallsUpdateAndSave_WhenAuthorIsValid()
        {
            // Arrange
            var author = new Author { AuthorId = 1, Name = "John Doe" };

            // Act
            await authorService.UpdateAuthorAsync(author);

            // Assert
            _authorRepositoryMock.Verify(repo => repo.UpdateAsync(author), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        //[Fact]
        //public async Task GetAuthorsByIdsAsync_ReturnsAuthors_WhenAuthorsExist()
        //{
        //    // Arrange
        //    var authorIds = new[] { 1, 2 };
        //    var authors = new List<Author>
        //    {
        //        new Author { AuthorId = 1, Name = "John Doe" },
        //        new Author { AuthorId = 2, Name = "Jane Smith" }
        //    }.AsQueryable();

        //    _authorRepositoryMock
        //        .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Author, bool>>>()))
        //        .Returns(authors);

        //    // Act
        //    var result = await authorService.GetAuthorsByIdsAsync(authorIds);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(2, result.Count());
        //}
    }
}
