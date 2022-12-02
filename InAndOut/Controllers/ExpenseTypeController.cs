using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseTypeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var expenseTypes = _dbContext.ExpenseTypes;

            return View(expenseTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExpenseTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var expenseType = new ExpenseType()
            {
               Name= model.Name,
            };

            _dbContext.ExpenseTypes.Add(expenseType);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expenseType = await _dbContext.ExpenseTypes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expenseType is null)
            {
                return NotFound();
            }

            return View(expenseType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpenseType(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expenseType = await _dbContext.ExpenseTypes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expenseType == null)
            {
                return NotFound();
            }

            _dbContext.ExpenseTypes.Remove(expenseType);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var expenseType = await _dbContext.ExpenseTypes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (expenseType is null)
            {
                return NotFound();
            }

            return View(new EditExpenseTypeViewModel()
            {
                Name = expenseType.Name,
                Id = expenseType.Id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditExpenseTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id <= 0)
            {
                return NotFound();
            }

            var expenseType = await _dbContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Id == model.Id);

            if (expenseType is null)
            {
                return NotFound();
            }

            expenseType.Name = model.Name;

            await _dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
