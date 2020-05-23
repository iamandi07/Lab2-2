using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesContext _context;

        public ExpensesController(ExpensesContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetExpensesClasses(
            [FromQuery] DateTime? from = null,
            [FromQuery] DateTime? to = null,
            [FromQuery] string type = null)
        {
            IQueryable<Expenses> expenses = _context.ExpensesClasses;

            if (from != null)
            {
                expenses = expenses.Where(item => from <= item.Date);
            }
            if (to != null)
            {
                expenses = expenses.Where(item => item.Date <= to);
            }
            if (type != null)
            {
                expenses = expenses.Where(item => item.Type == type);
            }

            return await expenses.Include(e => e.Comments).ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expenses>> GetExpenses(long id)
        {
            var expenses = await _context.ExpensesClasses.FindAsync(id);

            if (expenses == null)
            {
                return NotFound();
            }

            return expenses;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenses(long id, Expenses expenses)
        {
            if (id != expenses.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Expenses>> PostExpenses(Expenses expenses)
        {
            _context.ExpensesClasses.Add(expenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenses", new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expenses>> DeleteExpenses(long id)
        {
            var expenses = await _context.ExpensesClasses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }

            _context.ExpensesClasses.Remove(expenses);
            await _context.SaveChangesAsync();

            return expenses;
        }

        private bool ExpensesExists(long id)
        {
            return _context.ExpensesClasses.Any(e => e.Id == id);
        }
    }
}
