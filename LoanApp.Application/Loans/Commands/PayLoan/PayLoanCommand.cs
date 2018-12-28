using LoanApp.Application.Infrastructure;
using MediatR;

namespace LoanApp.Application.Loans.Commands.PayLoan
{
    public class PayLoanCommand : IRequest<Response>
    {
        public int LoanId { get; set; }
    }
}