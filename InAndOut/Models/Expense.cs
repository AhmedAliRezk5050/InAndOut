namespace InAndOut.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public string ExpenseName { get; set; } = null!;

        public int Amount { get; set; }
    }
}
