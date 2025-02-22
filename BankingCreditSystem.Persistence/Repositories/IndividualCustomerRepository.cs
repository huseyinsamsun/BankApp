using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Persistence.Contexts;

namespace BankingCreditSystem.Persistence.Repositories;

public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BankingCreditSystemDbContext>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BankingCreditSystemDbContext context) : base(context)
    {
    }
} 