using FluentValidation;

namespace LoanApp.Application.Loans.Commands.AddLoan
{
    public class AddLoanCommandValidator : AbstractValidator<AddLoanCommand>
    {
        public AddLoanCommandValidator()
        {
            RuleFor(x => x.LoanValue)
                .GreaterThan(0)
                .WithMessage("must be greater than 0");
        }
    }
}