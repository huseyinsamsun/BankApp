using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.Repositories.EntityFramework;
using BankingCreditSystem.Infrastructure.Contexts;

namespace BankingCreditSystem.Infrastructure.Repositories
{
    public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BaseDbContext>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<CorporateCustomer?> GetByTaxNumberAsync(string taxNumber)
        {
            return await Context.CorporateCustomers.FirstOrDefaultAsync(x => x.TaxNumber == taxNumber);
        }

        public async Task<IEnumerable<CorporateCustomer>> GetAllAsync()
        {
            return await Context.CorporateCustomers.ToListAsync();
        }

        public async Task<CorporateCustomer?> GetByIdAsync(int id)
        {
            return await Context.CorporateCustomers.FindAsync(id);
        }

        public async Task AddAsync(CorporateCustomer customer)
        {
            await Context.CorporateCustomers.AddAsync(customer);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CorporateCustomer customer)
        {
            Context.CorporateCustomers.Update(customer);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CorporateCustomer customer)
        {
            Context.CorporateCustomers.Remove(customer);
            await Context.SaveChangesAsync();
        }
    }
} 