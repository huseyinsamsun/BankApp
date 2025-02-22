using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(50);
        builder.Property(c => c.LastName).HasMaxLength(50);
        builder.Property(c => c.IdentityNumber).HasMaxLength(11);
        builder.Property(c => c.Occupation).HasMaxLength(100);
        builder.Property(c => c.EmployerName).HasMaxLength(100);
    }
} 