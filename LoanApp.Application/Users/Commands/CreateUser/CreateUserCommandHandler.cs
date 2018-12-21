using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
            var user = new User();
            user.EmailAddress = request.EmailAddress;
            user.FirstName = request.FirstName;
            user.IsBorrower = request.IsBorrower;
            user.IsLender = request.IsLender;
            user.LastName = request.LastName;
            await _context.Users.AddAsync(user);
            return Unit.Value;
        }
    }
}
