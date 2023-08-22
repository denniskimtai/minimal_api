
global using Microsoft.EntityFrameworkCore;
using MySql_Minimal_Api_Project.Models;

namespace MySql_Minimal_Api_Project.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<TransactionModel> TransactionItems => Set<TransactionModel>();
    }
}
