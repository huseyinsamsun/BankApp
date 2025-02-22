using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommand : IRequest<CorporateCustomerResponse>
{
    public Guid Id { get; set; }
    public UpdateCorporateCustomerRequest CustomerRequest { get; set; }

    public UpdateCorporateCustomerCommand(Guid id, UpdateCorporateCustomerRequest customerRequest)
    {
        Id = id;
        CustomerRequest = customerRequest;
    }
}

public class UpdateCorporateCustomerResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Message { get; set; }
} 