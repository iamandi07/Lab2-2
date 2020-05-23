using Microsoft.EntityFrameworkCore;

namespace Lab2.Models
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<Expenses> ExpensesClasses { get; set; }
    }
}
