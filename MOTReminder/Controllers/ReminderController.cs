using Microsoft.AspNetCore.Mvc;
using MOTReminder.Business;
using System.Linq;
using System.Threading.Tasks;

namespace MOTReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IMOTService _motService;

        public ReminderController(IMOTService motService)
        {
            _motService = motService;
        }

        public async Task<IActionResult> RegisterEmailReminderAsync(Business.DTO.Customer customer)
        {
            foreach (var vehicle in customer.Vehicles)
            {
                await _motService.RemindByEmail(customer.Email, vehicle);
            }
            return Ok(new
            {
                customer.Email,
                VehicleRegNumbers = string.Join(" ,", customer.Vehicles.Select(v => v.RegistrationNumber))
            });
        }
    }
}