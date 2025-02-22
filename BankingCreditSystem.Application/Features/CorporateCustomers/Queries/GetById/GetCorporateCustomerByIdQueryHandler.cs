using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;

public class GetCorporateCustomerByIdQueryHandler : IRequestHandler<GetCorporateCustomerByIdQuery, CorporateCustomerResponse>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public GetCorporateCustomerByIdQueryHandler(
        ICorporateCustomerRepository corporateCustomerRepository,
        IMapper mapper,
        CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CorporateCustomerResponse> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerShouldExist(request.Id);
        
        var customer = await _corporateCustomerRepository.GetAsync(request.Id);
        return _mapper.Map<CorporateCustomerResponse>(customer);
    }
} 