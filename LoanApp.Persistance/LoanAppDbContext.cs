using LoanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Persistance
{
    public class LoanAppDbContext : DbContext
    {
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
