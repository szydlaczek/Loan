using FluentValidation;

namespace LoanApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .WithMessage("cannot be null")
                .EmailAddress()
                .WithMessage("is in incorrect format");

            RuleFor(x => x.FirstName)
                .MaximumLength(60)
                .WithMessage("max length is 60")
                .NotEmpty()
                .WithMessage("cannot be empty");

            RuleFor(x => x.LastName)
                .MaximumLength(60)
                .WithMessage("max length is 60")
                .NotEmpty()
                .WithMessage("cannot be empty");
        }
    }
}