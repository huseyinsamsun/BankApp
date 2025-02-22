using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, IPaginate<IndividualCustomerResponse>>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public GetIndividualCustomerListQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<IPaginate<IndividualCustomerResponse>> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _individualCustomerRepository.GetListAsyncPaginate(
            index: request.Index,
            size: request.Size
        );

        return _mapper.Map<Paginate<IndividualCustomerResponse>>(customers);
    }
} 