using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;
using static BankingCreditSystem.Application.Features.Constants.Messages;

namespace BankingCreditSystem.Persistence.Repositories;

public class CorporateCustomerRepository : Core.Repositories.EfRepositoryBase<Domain.Entities.CorporateCustomer, Guid, BankingCreditSystemDbContext>, ICorporateCustomerRepository
{ 
    public CorporateCustomerRepository(BankingCreditSystemDbContext context) : base(context)
    {
    } 

    public async Task<Domain.Entities.CorporateCustomer?> GetByTaxNumberAsync(string taxNumber)
    {
        return await Context.Set<Domain.Entities.CorporateCustomer>()
            .FirstOrDefaultAsync(x => x.TaxNumber == taxNumber);
    }
} 