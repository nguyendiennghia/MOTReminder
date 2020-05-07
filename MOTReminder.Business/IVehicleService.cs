using MOTReminder.Business.DTO;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public interface IVehicleService
    {
        Task<Vehicle> GetDetailsByAsync(string regNumber);
    }
}
