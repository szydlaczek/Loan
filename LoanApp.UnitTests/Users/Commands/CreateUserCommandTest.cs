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

        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}