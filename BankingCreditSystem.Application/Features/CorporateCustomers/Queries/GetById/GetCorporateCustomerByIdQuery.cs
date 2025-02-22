using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;

public class GetCorporateCustomerByIdQuery : IRequest<CorporateCustomerResponse>
{
    public Guid Id { get; set; }

    public GetCorporateCustomerByIdQuery(Guid id)
    {
        Id = id;
    }
} 