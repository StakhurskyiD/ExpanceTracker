using ExpenseTracker.API.Models;
using ExpenseTracker.API.Repositories;
using ExpenseTracker.API.Repositories.Contracts;
using ExpenseTracker.API.Services.Contacts;
using MongoDB.Driver;

namespace ExpenseTracker.API.Services.Impl;

public class ExpenseService : IExpenseService
{
    private readonly IMongoCollection<Expense> _expenses;
    private readonly IMongoCollection<Category> _categories;

    public ExpenseService(IExpenseTrackerContext context)
    {
        _expenses = context.Expenses;
        _categories = context.Categories;
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
    {
        var expenses = await _expenses.Find(_ => true).ToListAsync();

        // Populate the Category field manually
        foreach (var expense in expenses)
        {
            expense.Category = await _categories.Find(c => c.CategoryId == expense.CategoryId).FirstOrDefaultAsync();
        }

        return expenses;
    }

    public async Task<Expense?> GetExpenseByIdAsync(Guid id)
    {
        var expense = await _expenses.Find(e => e.ExpenseId == id).FirstOrDefaultAsync();

        if (expense != null)
        {
            expense.Category = await _categories.Find(c => c.CategoryId == expense.CategoryId).FirstOrDefaultAsync();
        }

        return expense;
    }

    public async Task CreateExpenseAsync(Expense expense)
    {
        await _expenses.InsertOneAsync(expense);
    }
}