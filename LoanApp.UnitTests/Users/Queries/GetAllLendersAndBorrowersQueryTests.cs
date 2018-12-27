using LoanApp.Application.Users.Queries;
using LoanApp.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LoanApp.UnitTests.Users.Queries
{
    [Collection("QueryCollection")]
    public class GetAllLendersAndBorrowersQueryTests
    {
        private readonly LoanAppDbContext _context;
        private readonly GetAllLendersAndBorrowersQueryHandler _queryHandler;
        public GetAllLendersAndBorrowersQueryTests(TestFixture fixture)
        {
            _context = fixture.Context;
            _queryHandler = new GetAllLendersAndBorrowersQueryHandler(_context);
        }
        [Fact]
        public async Task GetAllUsersShouldReturnOneLenderAndOneBorrower()
        {
            var query = new GetAllLendersAndBorrowersQuery();
            var result = await _queryHandler.Handle(query, CancellationToken.None);
            Assert.Single(result.Lenders);
            Assert.Single(result.Borrowers);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
