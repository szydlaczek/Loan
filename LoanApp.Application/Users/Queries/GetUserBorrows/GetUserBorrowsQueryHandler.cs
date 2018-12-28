using LoanApp.Application.Users.Models;
using LoanApp.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApp.Application.Users.Queries.GetUserBorrows
{
    public class GetUserBorrowsQueryHandler : IRequestHandler<GetUserBorrowsQuery, ICollection<UserBorrowsPreviewDto>>
    {
        private readonly LoanAppDbContext _context;

        public GetUserBorrowsQueryHandler(LoanAppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserBorrowsPreviewDto>> Handle(GetUserBorrowsQuery request, CancellationToken cancellationToken)
        {
            var loans = await _context.Loans
                .Include(l => l.LoanType)
                .Include(l => l.Lender)
                .Where(u => u.BorrowerId == request.UserId)
                .ToListAsync();

            return loans.AsQueryable().Select(UserBorrowsPreviewDto.Projection).ToList();
        }
    }
}