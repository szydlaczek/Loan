using LoanApp.Application.Infrastructure;
using MediatR;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBorrower { get; set; }
        public bool IsLender { get; set; }
    }
}