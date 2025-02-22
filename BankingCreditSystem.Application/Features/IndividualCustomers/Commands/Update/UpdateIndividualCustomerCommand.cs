using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerResponse>
{
    public Guid Id { get; set; }
    public UpdateIndividualCustomerRequest CustomerRequest { get; set; }

    public UpdateIndividualCustomerCommand(Guid id, UpdateIndividualCustomerRequest customerRequest)
    {
        Id = id;
        CustomerRequest = customerRequest;
    }
}

public class UpdateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Message { get; set; }
} 