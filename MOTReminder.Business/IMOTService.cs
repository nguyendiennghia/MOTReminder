using MOTReminder.Business.DTO;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public interface IMOTService
    {
        Task RemindByEmail(string email, Vehicle vehicle);
        Task RemindBySMS(string phoneNumber, Vehicle vehicle);
    }
}
