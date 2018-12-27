using LoanApp.Application.Infrastructure;
using LoanApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApp.Application.Loans.Commands.PayLoan
{
    public class PayLoanCommandHandler : IRequestHandler<PayLoanCommand, Response>
    {
        private readonly LoanAppDbContext _context;
        public PayLoanCommandHandler(LoanAppDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Handle(PayLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _context.Loans.Where(l => l.Id == request.LoanId).FirstOrDefaultAsync();

            if (loan==null)
                return new Response().AddError($"Loan with Id {request.LoanId} doesnt exist");

            if (loan.IsPaid)
                return new Response().AddError($"Loan with Id {request.LoanId} has been already paid");

            loan.IsPaid = true;
            await _context.SaveChangesAsync();
            return new Response();
        }
    }
}
