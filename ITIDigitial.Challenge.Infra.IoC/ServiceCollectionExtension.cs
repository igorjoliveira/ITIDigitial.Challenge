using ITIDigitial.Challenge.Application.ApplicationServices;
using ITIDigitial.Challenge.Application.Interfaces.ApplicationServices;
using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ITIDigitial.Challenge.Infra.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISecurityApplicationService, SecurityApplicationService>();
            services.AddTransient<IPasswordValidationService, PasswordValidationService>();
        }
    }
}
