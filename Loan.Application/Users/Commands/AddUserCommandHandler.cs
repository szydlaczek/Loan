using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loan.Application.Users.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        public Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
