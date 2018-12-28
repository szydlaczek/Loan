using LoanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanApp.Persistence.Configurations
{
    public class LoanTypeConfiguration : IEntityTypeConfiguration<LoanType>
    {
        public void Configure(EntityTypeBuilder<LoanType> builder)
        {
            builder.HasKey(l => l.Id);
            builder.HasIndex(l => l.Name)
                .IsUnique();

            builder.HasData(new LoanType() { Id=1, Name = "Dinner" });
        }
    }
}
