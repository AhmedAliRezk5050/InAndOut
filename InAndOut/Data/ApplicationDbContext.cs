using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

        public DbSet<ExpenseType> ExpenseTypes { get; set; } = null!;

    }
}
