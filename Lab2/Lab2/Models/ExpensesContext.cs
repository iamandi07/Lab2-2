using Microsoft.EntityFrameworkCore;
using Lab2.Models;

namespace Lab2.Models
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<Expenses> ExpensesClasses { get; set; }
        public DbSet<Expenses> Comment { get; set; }
        public DbSet<Lab2.Models.Comment> Comment_1 { get; set; }
    }
}
