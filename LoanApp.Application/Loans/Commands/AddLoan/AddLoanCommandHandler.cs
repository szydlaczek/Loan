using LoanApp.Application.Exceptions;
using LoanApp.Application.Infrastructure;
using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApp.Application.Loans.Commands.AddLoan
{
    public class AddLoanCommandHandler : IRequestHandler<AddLoanCommand, Response>
    {
        private readonly LoanAppDbContext _context;

        public AddLoanCommandHandler(LoanAppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            if (request.LenderId == request.BorrowerId)
                return new Response().AddError("Borrower and Lender Id must not be the same");

            var loanType = await _context.LoanTypes.Where(l => l.Id == request.LoanTypeId).FirstOrDefaultAsync();

            if (loanType == null)
                return new Response().AddError("Loan type doesnt exists");
                
            var lender = await _context.Users.Where(l => l.Id == request.LenderId).FirstOrDefaultAsync();
            if (lender == null)
                return new Response().AddError($"User with Id {request.LenderId} doesnt exist");

            var borrower = await _context.Users.Where(b => b.Id == request.BorrowerId).FirstOrDefaultAsync();
            if (borrower == null)
                return new Response().AddError($"User with Id {request.BorrowerId} doesnt exist");

            var loan = new Loan();
            loan.Borrower = borrower;
            loan.IsPaid = false;
            loan.Lender = lender;
            loan.LoanType = loanType;
            loan.LoanValue = request.LoanValue;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync(cancellationToken);
            return new Response();
        }
    }
}