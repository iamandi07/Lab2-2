using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab2.Models
{
    public static class SeedData
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
                        Description = "apple",
                        Sum = 25.25,
                        Location = "Kaufland",
                        Date = DateTime.Parse("2020-04-07"),
                        Currency = "ron",
                        Type = "food",
                        Importance = Importance.low,
                        Status = Status.optional
                    },

                    new Expenses
                    {
                   
                        Description = "electricity",
                        Sum = 30,
                        Location = "Electrica",
                        Date = DateTime.Now,
                        Currency = "ron",
                        Type = "others",
                        Importance = Importance.high,
                        Status = Status.always
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
