using LoanApp.Application.Infrastructure;
using MediatR;

namespace LoanApp.Application.Loans.Commands.AddLoan
{
    public class AddLoanCommand : IRequest<Response>
    {
        public int LenderId { get; set; }
        public int BorrowerId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal LoanValue { get; set; }
    }
}