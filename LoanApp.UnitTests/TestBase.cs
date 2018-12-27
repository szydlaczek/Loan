using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.UnitTests
{
    public abstract class TestBase
    {
        private LoanAppDbContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<LoanAppDbContext>();
            builder.UseInMemoryDatabase("TestDb");
            builder.EnableSensitiveDataLogging();

            var dbContext = new LoanAppDbContext(builder.Options);

            return dbContext;
        }
    }
}