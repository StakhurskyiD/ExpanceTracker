using ExpenseTracker.API.Models;
using ExpenseTracker.API.Repositories.Contracts;
using ExpenseTracker.API.Services.Contacts;
using MongoDB.Driver;

namespace ExpenseTracker.API.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly IExpenseTrackerContext _context;

    public CategoryService(IExpenseTrackerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.Find(_ => true).ToListAsync();;
    }   
}