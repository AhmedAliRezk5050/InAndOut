using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class CreateExpenseViewModel
    {
        [Display(Name = "Expense", Prompt = "Expense")]
        public string ExpenseName { get; set; } = null!;

        // Required  + nullable
        // to avoid server side validation error message("" is invalid)
        [Required]
        [Display(Prompt = "Amount")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int? Amount { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public int? ExpenseTypeId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ExpenseTypesList { get; set; } = null!;
    }
}
