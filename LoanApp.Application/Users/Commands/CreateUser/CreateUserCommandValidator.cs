using FluentValidation;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.FirstName)
                .MaximumLength(60)
                .WithMessage("Max length is 60")
                .NotEmpty()
                .WithMessage("FirstName cannot be empty");
            RuleFor(x => x.LastName).MaximumLength(60);
        }
    }
}