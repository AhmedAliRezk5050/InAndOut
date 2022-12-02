using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

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
                ExpenseName= model.ExpenseName, 
                Amount = model.Amount ?? 0
            };

            _dbContext.Expenses.Add(expense);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
