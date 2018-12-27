using LoanApp.Application.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Application.Loans.Commands.PayLoan
{
    public class PayLoanCommand : IRequest<Response>
    {
        public int LoanId { get; set; }
    }
}
