using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Services.Repositories;

public interface ICorporateCustomerRepository : IAsyncRepository<CorporateCustomer, Guid>
{
    Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber);
} 