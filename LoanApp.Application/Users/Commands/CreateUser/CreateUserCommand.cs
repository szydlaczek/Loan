using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBorrower { get; set; }
        public bool IsLender { get; set; }
    }
}
