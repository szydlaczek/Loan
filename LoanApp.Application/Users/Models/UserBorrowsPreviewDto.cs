using LoanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LoanApp.Application.Users.Models
{
    public class UserBorrowsPreviewDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public string FromUser { get; set; }

        public static Expression<Func<Loan, UserBorrowsPreviewDto>> Projection
        {
            get
            {
                return p => new UserBorrowsPreviewDto
                {
                    Id=p.Id,
                    Type=p.LoanType.Name,
                    Value=p.LoanValue,
                    FromUser=$"{p.Lender.FirstName} {p.Lender.LastName} "
                };
            }
        }
    }
}
