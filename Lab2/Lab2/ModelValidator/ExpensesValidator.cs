using FluentValidation;
using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Lab2.ModelValidator
{
    public class ExpensesValidator : AbstractValidator<Expenses>
    {
        public ExpensesValidator()
        {
            RuleFor(x => x.Sum).GreaterThan(0);
        }
    }
}
