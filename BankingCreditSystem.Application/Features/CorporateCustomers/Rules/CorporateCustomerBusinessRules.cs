using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.Constants;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CustomerShouldExist(Guid id)
    {
        var customer = await _corporateCustomerRepository.GetAsync(id);
        if (customer == null) throw new Exception(Messages.CorporateCustomer.NotFound);
    }

    public async Task CustomerTaxNumberCannotBeDuplicated(string taxNumber)
    {
        var customer = await _corporateCustomerRepository.GetAsync(c => c.TaxNumber == taxNumber);
        if (customer != null) throw new Exception(Messages.CorporateCustomer.AlreadyExists);
    }
} 