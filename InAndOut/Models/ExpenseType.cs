namespace InAndOut.Models
{
    public class ExpenseType
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Expense> Expenses { get; set; } = null!;
    }
}
