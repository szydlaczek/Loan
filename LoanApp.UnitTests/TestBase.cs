using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.UnitTests
{
    public abstract class TestBase
    {       

        protected LoanAppDbContext InitAndGetDbContext()
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
                    IsBorrower = false,
                    IsLender = true
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
    }
}