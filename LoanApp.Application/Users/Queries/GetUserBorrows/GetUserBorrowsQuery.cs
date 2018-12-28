using LoanApp.Application.Users.Models;
using MediatR;
using System.Collections.Generic;

namespace LoanApp.Application.Users.Queries.GetUserBorrows
{
    public class GetUserBorrowsQuery : IRequest<ICollection<UserBorrowsPreviewDto>>
    {
        public int UserId { get; set; }
    }
}