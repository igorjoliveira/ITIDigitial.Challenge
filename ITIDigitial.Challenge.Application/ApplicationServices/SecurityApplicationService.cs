using ITIDigitial.Challenge.Application.Interfaces.ApplicationServices;
using ITIDigitial.Challenge.Domain.Aggregates.SecurityAggregate.Services;
using System.Threading.Tasks;

namespace ITIDigitial.Challenge.Application.ApplicationServices
{
    public class SecurityApplicationService : ISecurityApplicationService
    {
        private readonly IPasswordValidationService _passwordValidationService;

        public SecurityApplicationService(IPasswordValidationService passwordValidationService)
        {
            _passwordValidationService = passwordValidationService;
        }

        public async Task<bool> ValidatePasswordAsync(string password)
            => await Task.Run(() => !string.IsNullOrEmpty(password) && _passwordValidationService.Validate(password));
    }
}
