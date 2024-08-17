
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
        
    public ICollection<Expense> Expenses { get; set; }
}