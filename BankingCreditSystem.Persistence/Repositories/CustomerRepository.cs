using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class CustomerRepository : EfRepositoryBase<Customer, Guid, BankingCreditSystemDbContext>, ICustomerRepository
{
    public CustomerRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 