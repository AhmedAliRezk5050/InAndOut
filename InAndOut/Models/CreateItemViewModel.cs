using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class CreateItemViewModel
    {
        [Display(Name = "Item Name", Prompt = "Item Name")]
        public string ItemName { get; set; } = null!;

        [Display(Prompt = "Borrower")]
        public string Borrower { get; set; } = null!;

        [Display(Prompt = "Lender")]
        public string Lender { get; set; } = null!;
    }
}
