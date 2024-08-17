using ExpenseTracker.API.Models;
using ExpenseTracker.API.Services.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]  // Fixed the namespace for Route
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
    {
        return Ok(await _expenseService.GetAllExpensesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(Guid id)
    {
        var expense = await _expenseService.GetExpenseByIdAsync(id);
        if (expense == null) 
            return NotFound();
        
        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult> CreateExpense(Expense expense)
    {
        await _expenseService.CreateExpenseAsync(expense);
        return CreatedAtAction(nameof(GetExpense), new { id = expense.ExpenseId }, expense);
    }
}