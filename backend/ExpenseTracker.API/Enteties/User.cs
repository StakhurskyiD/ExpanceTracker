using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
        
    public ICollection<Expense> Expenses { get; set; }
}