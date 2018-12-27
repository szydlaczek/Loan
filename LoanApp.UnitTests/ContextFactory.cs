using LoanApp.Domain.Entities;
using LoanApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.UnitTests
{
    public class ContextFactory
    {
        public static LoanAppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<LoanAppDbContext>()
                .UseInMemoryDatabase("Test")
                .Options;

            var context = new LoanAppDbContext(options);
            context.Database.EnsureCreated();
            var user1 = new User
            {
                EmailAddress = "Kathy.Matthews@gmail.com",
                FirstName = "Kathy",
                LastName = "Matthews",
                IsBorrower = true,
                IsLender = false
            };

            var user2 = new User
            {
                EmailAddress = "Pablo.Jorreto@gmail.com",
                FirstName = "Pablo",
                LastName = "Jorreto",
                IsBorrower = false,
                IsLender = true
            };

            var loanType = new LoanType
            {
                Name = "Shopping"
            };

            var loan1 = new Loan
            {
                Borrower = user1,
                Lender = user2,
                LoanType = loanType,
                IsPaid = false,
                LoanValue = 100
            };
            var loan2 = new Loan
            {
                Borrower = user1,
                Lender = user2,
                LoanType = loanType,
                IsPaid = true,
                LoanValue = 1000
            };
            context.LoanTypes.Add(loanType);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Loans.Add(loan1);
            context.Loans.Add(loan2);
            context.SaveChanges();
            return context;
        }
        public static void Destroy(LoanAppDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
