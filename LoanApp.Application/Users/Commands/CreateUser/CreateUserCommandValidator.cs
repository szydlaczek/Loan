using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.FirstName).MaximumLength(60);
            RuleFor(x => x.LastName).MaximumLength(60);
        }
    }
}
