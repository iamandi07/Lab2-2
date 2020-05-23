using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExpensesContext(serviceProvider.GetRequiredService<DbContextOptions<ExpensesContext>>()))
            {
                // Look for any movies.
                if (context.ExpensesClasses.Any())
                {
                    return;   // DB table has been seeded
                }

                context.ExpensesClasses.AddRange(
                    new Expenses
                    {
                        Id = 1,
                        Description = "apple",
                        Sum = 25.25,
                        Location = "Kaufland",
                        Date = DateTime.Parse("2020-04-07"),
                        Currency = "ron",
                        Type = "food",
                        Importance = Importance.low,
                        Status = Status.optional
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
