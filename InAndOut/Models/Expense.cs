namespace InAndOut.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string ExpenseName { get; set; } = null!;

        public int Amount { get; set; }

        public int ExpenseTypeId { get; set; }

        public ExpenseType ExpenseType { get; set; } = null!;
    }
}
