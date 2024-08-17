using MongoDB.Driver;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.Repositories.Contracts;

namespace ExpenseTracker.API.Repositories
{
    public class ExpenseTrackerContext : IExpenseTrackerContext
    {
        private readonly IMongoDatabase _database;

        public ExpenseTrackerContext(IMongoClient client, MongoDbSettings settings)
        {
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Expense> Expenses => _database.GetCollection<Expense>("Expenses");
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
    }
}