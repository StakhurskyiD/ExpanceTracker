using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Services.Contacts;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}