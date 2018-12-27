using LoanApp.Application.Users.Commands.CreateUser;
using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests.Users.Commands
{
    public class CreateUserCommandTest : TestBase
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
        public async Task CreateUserShouldThrowArgumentException()
        {
            var createUserCommand = new CreateUserCommand();
            createUserCommand.EmailAddress = "Pablo.Jorreto@gmail.com";
            createUserCommand.FirstName = "Grzegorz";
            createUserCommand.LastName = "Szydło";
            createUserCommand.IsLender = true;
            createUserCommand.IsBorrower = true;
            //await _commandHandler.Handle(createUserCommand, CancellationToken.None);
            await Assert.ThrowsAsync<ArgumentException>(async () => await _commandHandler.Handle(createUserCommand, CancellationToken.None));
        }

        private LoanAppDbContext InitAndGetDbContext()
        {
            var context = GetDbContext();
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
            context.Users.Add(user1);
            context.Users.Add(user2);
            
            context.SaveChanges();
            
            return context;
        }
    }
}
