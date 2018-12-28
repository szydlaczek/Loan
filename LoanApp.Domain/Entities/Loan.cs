namespace LoanApp.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }
        public decimal LoanValue { get; set; }
        public int BorrowerId { get; set; }
        public int LenderId { get; set; }
        public User Lender { get; set; }
        public User Borrower { get; set; }
        public bool IsPaid { get; set; }
    }
}