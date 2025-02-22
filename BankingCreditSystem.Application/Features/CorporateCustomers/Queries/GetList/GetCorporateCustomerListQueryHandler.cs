using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;

public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, IPaginate<CorporateCustomerResponse>>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;

    public GetCorporateCustomerListQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
    }

    public async Task<IPaginate<CorporateCustomerResponse>> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _corporateCustomerRepository.GetListAsyncPaginate(
            index: request.Index,
            size: request.Size
        );

        return _mapper.Map<Paginate<CorporateCustomerResponse>>(customers);
    }
} 