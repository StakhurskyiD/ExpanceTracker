using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Services.Contacts;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task CreateUserAsync(User user);
}