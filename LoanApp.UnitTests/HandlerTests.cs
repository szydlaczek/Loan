using LoanApp.Application.Users.Commands.CreateUser;
using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests
{
    public class HandlerTests
    {
        [Fact]
        public async Task CreateUser()
        {
            var options = new DbContextOptionsBuilder<LoanAppDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new LoanAppDbContext(options))
            {
                var handler = new CreateUserCommandHandler(context);
                await handler.Handle(new CreateUserCommand() { EmailAddress = "aa", }, new System.Threading.CancellationToken());
            }

        }
    }
}
