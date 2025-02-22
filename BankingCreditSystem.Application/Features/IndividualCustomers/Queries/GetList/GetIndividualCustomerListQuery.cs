using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

public class GetIndividualCustomerListQuery : IRequest<IPaginate<IndividualCustomerResponse>>
{
    public int Index { get; set; } = 0;
    public int Size { get; set; } = 10;
} 