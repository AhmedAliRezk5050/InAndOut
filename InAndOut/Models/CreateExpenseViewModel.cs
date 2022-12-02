using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class CreateExpenseViewModel
    {
        [Display(Name = "Expense", Prompt = "Expense")]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Display(Prompt = "Amount")]
        public int? Amount { get; set; }
    }
}
