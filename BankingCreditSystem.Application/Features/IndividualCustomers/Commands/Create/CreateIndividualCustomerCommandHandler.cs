using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Application.Features.Constants;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponse>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IMapper _mapper;

    public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _mapper = mapper;
    }

    public async Task<CreateIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        var individualCustomer = _mapper.Map<IndividualCustomer>(request);
        var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);

        return new CreateIndividualCustomerResponse
        {
            Id = createdCustomer.Id,
            FullName = $"{createdCustomer.FirstName} {createdCustomer.LastName}",
            Message = Messages.IndividualCustomer.Created
        };
    }
} 