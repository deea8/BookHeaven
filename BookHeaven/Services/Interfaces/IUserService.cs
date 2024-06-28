using BookHeaven.Models;
using System.Linq.Expressions;

namespace BookHeaven.Services.Interfaces
{
    public interface IUserService
    {
        Task <List<User>> GetUsersAsync();
        Task <List<User>> GetUsersByConditionAsync(Expression<Func<User, bool>> expression);

        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
