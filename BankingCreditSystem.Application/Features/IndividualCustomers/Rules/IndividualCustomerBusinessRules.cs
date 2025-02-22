using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.Constants;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task CustomerShouldExist(Guid id)
    {
        var customer = await _individualCustomerRepository.GetAsync(id);
        if (customer == null) throw new Exception(Messages.IndividualCustomer.NotFound);
    }

    public async Task CustomerIdentityNumberCannotBeDuplicated(string identityNumber)
    {
        var customer = await _individualCustomerRepository.GetAsync(c => c.IdentityNumber == identityNumber);
        if (customer != null) throw new Exception(Messages.IndividualCustomer.AlreadyExists);
    }
} 