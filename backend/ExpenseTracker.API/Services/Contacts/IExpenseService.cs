using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Services.Contacts;

public interface IExpenseService
{
    Task<IEnumerable<Expense>> GetAllExpensesAsync();
    Task<Expense> GetExpenseByIdAsync(Guid id);
    Task CreateExpenseAsync(Expense expense);
}