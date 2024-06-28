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
using BookHeaven.Tests.Services;


namespace BookHeaven.Tests.Services
{
    public class BookServiceTests
    {
        private IBookService _bookService;
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        private readonly Mock<IBookRepository> _bookRepositoryMock = new Mock<IBookRepository>();
        private readonly Mock<IPublisherRepository> _publisherRepositoryMock = new Mock<IPublisherRepository>();
        private readonly Mock<IAuthorRepository> _authorRepositoryMock = new Mock<IAuthorRepository>();

        public BookServiceTests()
        {
            _repositoryWrapperMock.Setup(rw => rw.BookRepository).Returns(_bookRepositoryMock.Object);
            _repositoryWrapperMock.Setup(rw => rw.PublisherRepository).Returns(_publisherRepositoryMock.Object);
            _repositoryWrapperMock.Setup(rw => rw.AuthorRepository).Returns(_authorRepositoryMock.Object);
            _bookService = new BookService(_repositoryWrapperMock.Object);
        }

    

        [Fact]
        public async Task AddBookAsync_CallsAddAndSave_WhenBookIsValid()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Test Book" };

            // Act
            await _bookService.AddBookAsync(book);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.AddAsync(book), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteBookAsync_CallsDeleteAndSave_WhenBookIsValid()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Test Book" };

            // Act
            await _bookService.DeleteBookAsync(book);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.DeleteAsync(book), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateBookAsync_CallsUpdateAndSave_WhenBookIsValid()
        {
            // Arrange
            var book = new Book { BookId = 1, Title = "Updated Book" };

            // Act
            await _bookService.UpdateBookAsync(book);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.UpdateAsync(book), Times.Once);
            _repositoryWrapperMock.Verify(rw => rw.SaveAsync(), Times.Once);
        }
    }
}
