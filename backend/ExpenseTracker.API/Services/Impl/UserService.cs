using ExpenseTracker.API.Models;
using ExpenseTracker.API.Repositories;
using ExpenseTracker.API.Repositories.Contracts;
using ExpenseTracker.API.Services.Contacts;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ExpenseTracker.API.Services.Impl;

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(IExpenseTrackerContext context)
    {
        _users = context.Users;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateUserAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }
}