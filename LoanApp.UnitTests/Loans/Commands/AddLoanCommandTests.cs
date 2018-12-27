using LoanApp.Application.Infrastructure;
using LoanApp.Application.Loans.Commands.AddLoan;
using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests.Loans.Commands
{
    public class AddLoanCommandTests : TestBase, IDisposable
    {
        private readonly LoanAppDbContext _context;
        private readonly AddLoanCommandHandler _commandHandler;

        public AddLoanCommandTests()
        {
            _context = InitAndGetDbContext();
            _commandHandler = new AddLoanCommandHandler(_context);
        }

        [Fact]
        public async Task AddLoanShouldReturnSingleError()
        {
            Response result;
            var command = new AddLoanCommand();
            command.BorrowerId = 1;
            command.LenderId = 1;
            result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Equal("Borrower and Lender Id must not be the same", result.Errors.FirstOrDefault());
            command.LenderId = 2;
            command.LoanTypeId = 2;
            result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Equal("Loan type doesnt exists", result.Errors.FirstOrDefault());
            command.LoanTypeId = 1;
            command.LenderId = 3;
            result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Equal($"User with Id {command.LenderId} doesnt exist", result.Errors.FirstOrDefault());
            command.LenderId = 2;
            command.BorrowerId = 3;
            Assert.Equal($"User with Id {command.BorrowerId} doesnt exist", result.Errors.FirstOrDefault());
        }

        [Fact]
        public async Task AddLoanShouldReturnNoError()
        {
            Response result;
            var command = new AddLoanCommand();
            command.BorrowerId = 1;
            command.LenderId = 2;
            command.LoanTypeId = 1;
            command.LoanValue = 100;
            result = await _commandHandler.Handle(command, CancellationToken.None);
            Assert.Empty(result.Errors);
        }

        private LoanAppDbContext InitAndGetDbContext()
        {
            var builder = new DbContextOptionsBuilder<LoanAppDbContext>();
            builder.UseInMemoryDatabase("Test");
            builder.EnableSensitiveDataLogging();

            var context = new LoanAppDbContext(builder.Options);
            if (context.Database.EnsureCreated())
            {
                var user1 = new User
                {
                    EmailAddress = "Kathy.Matthews@gmail.com",
                    FirstName = "Kathy",
                    LastName = "Matthews",
                    IsBorrower = true,
                    IsLender = false
                };

                var user2 = new User
                {
                    EmailAddress = "Pablo.Jorreto@gmail.com",
                    FirstName = "Pablo",
                    LastName = "Jorreto",
                    IsBorrower = true,
                    IsLender = false
                };

                var loanType = new LoanType
                {
                    Name = "Shopping"
                };
                context.LoanTypes.Add(loanType);
                context.Users.Add(user1);
                context.Users.Add(user2);
                context.SaveChanges();
            }

            return context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}