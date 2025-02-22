using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.Property(c => c.CompanyName).HasMaxLength(250);
        builder.Property(c => c.TradeRegistryNumber).HasMaxLength(50);
        builder.Property(c => c.CompanyType).HasMaxLength(50);
        builder.Property(c => c.AuthorizedPersonName).HasMaxLength(100);
        builder.Property(c => c.AuthorizedPersonTitle).HasMaxLength(100);
    }
} 