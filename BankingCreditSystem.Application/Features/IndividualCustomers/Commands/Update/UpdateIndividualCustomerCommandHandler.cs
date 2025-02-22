using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Application.Features.Constants;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public UpdateIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IMapper mapper,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdateIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerShouldExist(request.Id);

        var customer = await _individualCustomerRepository.GetAsync(request.Id);
        _mapper.Map(request, customer);
        
        var updatedCustomer = await _individualCustomerRepository.UpdateAsync(customer);

        return new UpdateIndividualCustomerResponse
        {
            Id = updatedCustomer.Id,
            FullName = $"{updatedCustomer.FirstName} {updatedCustomer.LastName}",
            Message = Messages.IndividualCustomer.Updated
        };
    }
} 