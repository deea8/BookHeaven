using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BookHeaven.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task AddUserAsync(User user)
        {
            await _repositoryWrapper.UserRepository.AddAsync(user);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            await _repositoryWrapper.UserRepository.DeleteAsync(user);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repositoryWrapper.UserRepository.UpdateAsync(user);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return  await _repositoryWrapper.UserRepository.FindAll().ToListAsync();
        }
        public async Task<List<User>> GetUsersByConditionAsync(Expression<Func<User, bool>> expression)
        {
            return await _repositoryWrapper.UserRepository.FindByCondition(expression).ToListAsync();
        }

    }
}
