using LoanApp.Application.Users.Models;
using LoanApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApp.Application.Users.Queries
{
    public class GetAllLendersAndBorrowersQueryHandler : IRequestHandler<GetAllLendersAndBorrowersQuery, LenderAndBorrowerPreviewDto>
    {
        private readonly LoanAppDbContext _context;

        public GetAllLendersAndBorrowersQueryHandler(LoanAppDbContext context)
        {
            _context = context;
        }

        public async Task<LenderAndBorrowerPreviewDto> Handle(GetAllLendersAndBorrowersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Users.ToListAsync();
            var result = new LenderAndBorrowerPreviewDto
            {
                Borrowers = data.Where(b => b.IsBorrower).AsQueryable().Select(UserPreviewDto.Projection).ToList(),
                Lenders = data.Where(l => l.IsLender).AsQueryable().Select(UserPreviewDto.Projection).ToList()
            };
            return result;
        }
    }
}