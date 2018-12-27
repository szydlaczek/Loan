using LoanApp.Application.Users.Commands.CreateUser;
using LoanApp.Application.Users.Queries;
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
                await handler.Handle(new CreateUserCommand() { EmailAddress = "aa2", }, new System.Threading.CancellationToken());
            }

        }
        [Fact]
        public async Task Get_All_Borrowers_And_Lenders()
        {
            var options = new DbContextOptionsBuilder<LoanAppDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var context = new LoanAppDbContext(options))
            {
                context.Users.Add(new User { EmailAddress="sz", FirstName="grzegorz",  IsBorrower=true, IsLender=false, LastName="szyd" });
                context.Users.Add(new User { EmailAddress = "aa1", FirstName = "grzegorz",  IsBorrower = false, IsLender = true, LastName = "szyd" });
                await context.SaveChangesAsync();
            }

            using (var context = new LoanAppDbContext(options))
            {
                var handler = new GetAllLendersAndBorrowersQueryHandler(context);

                var result=await handler.Handle(new GetAllLendersAndBorrowersQuery(), new System.Threading.CancellationToken());
                Assert.Equal(1, result.Lenders.Count);
            }

        }
    }
}
