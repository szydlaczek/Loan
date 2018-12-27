using LoanApp.Application.Infrastructure;
using LoanApp.Application.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Application.Users.Queries.GetUserBorrows
{
    public  class GetUserBorrowsQuery : IRequest<ICollection<UserBorrowsPreviewDto>>
    {
        public int UserId { get; set; }
    }
}
