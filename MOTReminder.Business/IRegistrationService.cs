using MOTReminder.Business.DTO;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public interface IRegistrationService
    {
        Task ProcessAsync(Customer customer);
    }
}
