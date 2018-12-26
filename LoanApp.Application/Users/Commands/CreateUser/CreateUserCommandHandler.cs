using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly LoanAppDbContext _context;

        public CreateUserCommandHandler(LoanAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Users.Where(d => string.Equals(d.EmailAddress, request.EmailAddress, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
            if (user != null)
                throw new ArgumentException($"Email {request.EmailAddress} already exists, choose another", nameof(CreateUserCommand));
            user.EmailAddress = request.EmailAddress;
            user.FirstName = request.FirstName;
            user.IsBorrower = request.IsBorrower;
            user.IsLender = request.IsLender;
            user.LastName = request.LastName;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}