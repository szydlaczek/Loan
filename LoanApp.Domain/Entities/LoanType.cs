﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApp.Domain.Entities
{
    public class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
