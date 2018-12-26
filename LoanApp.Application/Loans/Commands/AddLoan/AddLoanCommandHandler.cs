using LoanApp.Application.Exceptions;
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
    public class AddLoanCommandHandler : IRequestHandler<AddLoanCommand, Unit>
    {
        private readonly LoanAppDbContext _context;

        public AddLoanCommandHandler(LoanAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            if (request.LenderId == request.BorrowerId)
                throw new ArgumentException("Borrower and Lender Id must not be the same", nameof(AddLoanCommand));

            var loanType = await _context.LoanTypes.Where(l => l.Id == request.LoanTypeId).FirstOrDefaultAsync();
            if (loanType == null)
                throw new NotFoundException(nameof(LoanType), request.LoanTypeId);
            var lender = await _context.Users.Where(l => l.Id == request.LenderId).FirstOrDefaultAsync();
            if (lender == null)
                throw new NotFoundException(nameof(User), request.LenderId);

            var borrower = await _context.Users.Where(b => b.Id == request.BorrowerId).FirstOrDefaultAsync();
            if (borrower == null)
                throw new NotFoundException(nameof(User), request.BorrowerId);

            var loan = new Loan();
            loan.Borrower = borrower;
            loan.IsPaid = false;
            loan.Lender = lender;
            loan.LoanType = loanType;
            loan.LoanValue = request.LoanValue;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}