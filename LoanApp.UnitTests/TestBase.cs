using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoanApp.UnitTests
{
    public abstract class TestBase
    {

        public LoanAppDbContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<LoanAppDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            builder.EnableSensitiveDataLogging();
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            var dbContext = new LoanAppDbContext(builder.Options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}