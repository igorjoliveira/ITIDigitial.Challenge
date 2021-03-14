using System.Threading.Tasks;

namespace ITIDigitial.Challenge.Application.Interfaces.ApplicationServices
{
    public interface ISecurityApplicationService
    {
        Task<bool> ValidatePasswordAsync(string password);
    }
}
