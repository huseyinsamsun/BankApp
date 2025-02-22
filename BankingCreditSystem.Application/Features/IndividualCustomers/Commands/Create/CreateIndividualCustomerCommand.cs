using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest CustomerRequest { get; set; }

    public CreateIndividualCustomerCommand(CreateIndividualCustomerRequest customerRequest)
    {
        CustomerRequest = customerRequest;
    }
}

public class CreateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Message { get; set; }
} 