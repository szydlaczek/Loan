using LoanApp.Persistence;
using System;
using Xunit;

namespace LoanApp.UnitTests
{
    public class TestFixture : IDisposable
    {
       public LoanAppDbContext Context { get; private set; }
        public TestFixture()
        {
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<TestFixture> { }
}