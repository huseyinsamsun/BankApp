using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CorporateCustomerResponse>
{
    public CreateCorporateCustomerRequest CustomerRequest { get; set; }

    public CreateCorporateCustomerCommand(CreateCorporateCustomerRequest customerRequest)
    {
        CustomerRequest = customerRequest;
    }
}

public class CreateCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Message { get; set; }
} 