using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var expenses = _dbContext.Expenses;

            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExpenseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var expense = new Expense()
            {
                ExpenseName = model.ExpenseName,
                Amount = model.Amount ?? 0
            };

            _dbContext.Expenses.Add(expense);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expense = await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expense is null)
            {
                return NotFound();
            }

            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expense = await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            _dbContext.Expenses.Remove(expense);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expense = await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expense is null)
            {
                return NotFound();
            }

            return View(new EditExpenseViewModel()
            {
                Amount = expense.Amount,
                ExpenseName = expense.ExpenseName,
                Id = expense.Id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditExpenseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id <= 0)
            {
                return NotFound();
            }

            var expense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == model.Id);

            if (expense is null)
            {
                return NotFound();
            }

            expense.ExpenseName = model.ExpenseName;
            expense.Amount = model.Amount ?? 0;

            await _dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
