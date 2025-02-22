using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;

public class GetCorporateCustomerListQuery : IRequest<IPaginate<CorporateCustomerResponse>>
{
    public int Index { get; set; } = 0;
    public int Size { get; set; } = 10;
} 