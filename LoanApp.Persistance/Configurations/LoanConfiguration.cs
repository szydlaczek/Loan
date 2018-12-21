using LoanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(t => t.LoanType)
                .WithMany(t => t.Loans)
                .HasForeignKey(f => f.LoanTypeId);

            builder.HasOne(b => b.Lender)
                .WithMany(d => d.SomeOneLoans)
                .HasForeignKey(d => d.LenderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Borrower)
                .WithMany(l => l.MyLoans)
                .HasForeignKey(l => l.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
