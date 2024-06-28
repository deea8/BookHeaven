using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHeaven.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public async Task<Author?> GetAuthorByNameAsync(string name)
        {
            return await _repositoryWrapper.AuthorRepository.FindByCondition(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _repositoryWrapper.AuthorRepository.AddAsync(author);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            await _repositoryWrapper.AuthorRepository.DeleteAsync(author);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _repositoryWrapper.AuthorRepository.FindAll().ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _repositoryWrapper.AuthorRepository.FindByCondition(a => a.AuthorId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _repositoryWrapper.AuthorRepository.UpdateAsync(author);
            await _repositoryWrapper.SaveAsync();
        }

        //public async Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId)
        //{
        //    var authors = await _repositoryWrapper.AuthorRepository
        //        .FindByCondition(a => a.BookAuthors.Any(ba => ba.BookId == bookId))
        //        .ToListAsync();

        //    return authors;
        //}
        public async Task<IEnumerable<Author>> GetAuthorsByIdsAsync(int[] ids)
        {
            return await _repositoryWrapper.AuthorRepository
                .FindByCondition(a => ids.Contains(a.AuthorId))
                .ToListAsync();
        }

    }
}
