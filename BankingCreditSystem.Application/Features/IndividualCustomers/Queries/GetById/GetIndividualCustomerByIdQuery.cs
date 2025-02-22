using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;

public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerResponse>
{
    public Guid Id { get; set; }

    public GetIndividualCustomerByIdQuery(Guid id)
    {
        Id = id;
    }
}

public class IndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentityNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    // Diğer özellikler...
} 