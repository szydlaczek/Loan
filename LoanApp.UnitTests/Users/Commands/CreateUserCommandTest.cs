using LoanApp.Application.Users.Commands.CreateUser;
using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests.Users.Commands
{
    public class CreateUserCommandTest : TestBase, IDisposable
    {
        private readonly LoanAppDbContext _context;
        private readonly CreateUserCommandHandler _commandHandler;

        public CreateUserCommandTest()
        {
            _context = InitAndGetDbContext();
            _commandHandler = new CreateUserCommandHandler(_context);
        }

        [Fact]
        public async Task NewUserShouldBeCreated()
        {
            var createUserCommand = new CreateUserCommand();
            createUserCommand.EmailAddress = "grzegorz.szydlo@outlook.com";
            createUserCommand.FirstName = "Grzegorz";
            createUserCommand.LastName = "Szydło";
            createUserCommand.IsLender = true;
            createUserCommand.IsBorrower = true;
            await _commandHandler.Handle(createUserCommand, CancellationToken.None);
            Assert.Equal(3, _context.Users.Count());
        }

        [Fact]
        public async Task CreateUserShouldReturnSingleError()
        {
            var createUserCommand = new CreateUserCommand();
            createUserCommand.EmailAddress = "Pablo.Jorreto@gmail.com";
            createUserCommand.FirstName = "Grzegorz";
            createUserCommand.LastName = "Szydło";
            createUserCommand.IsLender = true;
            createUserCommand.IsBorrower = true;
            var result = await _commandHandler.Handle(createUserCommand, CancellationToken.None);
            Assert.Single(result.Errors);
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