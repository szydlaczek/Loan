using LoanApp.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace LoanApp.Application.Users.Models
{
    public class UserPreviewDto
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBorrower { get; set; }
        public bool IsLender { get; set; }

        public static Expression<Func<User, UserPreviewDto>> Projection
        {
            get
            {
                return p => new UserPreviewDto
                {
                    UserId = p.Id,
                    LastName = p.LastName,
                    FirstName = p.FirstName,
                    EmailAddress = p.EmailAddress,
                    IsBorrower = p.IsBorrower,
                    IsLender = p.IsLender
                };
            }
        }
    }
}