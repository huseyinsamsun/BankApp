using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Individual Customer Mappings
        CreateMap<IndividualCustomer, IndividualCustomerResponse>().ReverseMap();
        CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();

        // Corporate Customer Mappings
        CreateMap<CorporateCustomer, CorporateCustomerResponse>().ReverseMap();
        CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();

        // Paginate Mappings
        CreateMap<Paginate<IndividualCustomer>, Paginate<IndividualCustomerResponse>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        CreateMap<Paginate<CorporateCustomer>, Paginate<CorporateCustomerResponse>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
    }
} 