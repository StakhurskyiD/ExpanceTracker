using ExpenseTracker.API.Models;
using MongoDB.Driver;

namespace ExpenseTracker.API.Repositories.Contracts;

public interface IExpenseTrackerContext
{
    IMongoCollection<User> Users { get; }
    IMongoCollection<Expense> Expenses { get; }
    IMongoCollection<Category> Categories { get; }
}