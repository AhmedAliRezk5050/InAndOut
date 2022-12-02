using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class EditExpenseViewModel : CreateExpenseViewModel
    {
        public int Id { get; set; }
    }
}
