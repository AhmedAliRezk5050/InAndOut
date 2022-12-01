namespace InAndOut.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = null!;
        public string Borrower { get; set; } = null!;
        
        public string Lender { get; set; } = null!;
    }
}
