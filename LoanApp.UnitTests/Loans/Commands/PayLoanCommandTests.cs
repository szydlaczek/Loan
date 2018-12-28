using LoanApp.Application.Loans.Commands.PayLoan;
using LoanApp.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests.Loans.Commands
{
    [Collection("QueryCollection")]
    public class PayLoanCommandTests
    {
        private readonly LoanAppDbContext _context;
        private readonly PayLoanCommandHandler _commandHandler;

        public PayLoanCommandTests(TestFixture fixture)
        {
            _context = fixture.Context;
            _commandHandler = new PayLoanCommandHandler(_context);
        }

        [Fact]
        public async Task PayLoanShouldReturnLoanDoesntExist()
        {
            var command = new PayLoanCommand();
            command.LoanId = 100;
            var result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Equal($"Loan with Id {command.LoanId} doesnt exist", result.Errors.FirstOrDefault());
        }

        [Fact]
        public async Task PayLoanShouldReturnNoError()
        {
            var command = new PayLoanCommand();
            command.LoanId = 1;
            var result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task PayLoanShouldReturnLoanHasBeenPaid()
        {
            var command = new PayLoanCommand();
            command.LoanId = 1;
            var result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Equal($"Loan with Id {command.LoanId} has been already paid", result.Errors.FirstOrDefault());
        }
    }
}