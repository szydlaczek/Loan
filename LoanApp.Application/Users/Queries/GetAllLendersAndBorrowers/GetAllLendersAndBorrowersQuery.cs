using LoanApp.Application.Users.Models;
using MediatR;

namespace LoanApp.Application.Users.Queries
{
    public class GetAllLendersAndBorrowersQuery : IRequest<LenderAndBorrowerPreviewDto>
    {
    }
}