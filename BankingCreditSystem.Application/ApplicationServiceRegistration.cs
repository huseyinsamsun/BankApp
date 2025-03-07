using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        // Diğer business rules'lar buraya eklenecek
        
        return services;
    }
} 