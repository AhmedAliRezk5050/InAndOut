using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class CreateExpenseTypeViewModel
    {
        [Display(Prompt = "Name")]
        public string Name { get; set; } = null!;
    }
}
