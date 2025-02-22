using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;

public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public GetIndividualCustomerByIdQueryHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<IndividualCustomerResponse> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerShouldExist(request.Id);

        var customer = await _individualCustomerRepository.GetAsync(request.Id);
        return _mapper.Map<IndividualCustomerResponse>(customer);
    }
} 