using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOTReminder.Business;
using MOTReminder.Models;
using MOTReminder.Utils;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MOTReminder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRegistrationService _registrationService;
        private readonly ReminderController _reminder;
        private readonly IRegistrationHelper _helper;

        public HomeController(ILogger<HomeController> logger, IRegistrationService registrationService, ReminderController reminder, IRegistrationHelper helper)
        {
            _logger = logger;
            _registrationService = registrationService;
            _reminder = reminder;
            _helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
                return View("Index", customer);

            var customerWithVehicle = new Business.DTO.Customer
            {
                Email = customer.Email,
                Vehicles = new[] { new Business.DTO.Vehicle { RegistrationNumber = customer.RegistrationNumber } }
            };
            await _registrationService.ProcessAsync(customerWithVehicle);

            await _reminder.RegisterEmailReminderAsync(customerWithVehicle);

            return View("Registered", new Registration { Customer = customerWithVehicle, DaysBeforeExpiry = _helper.DaysBeforeExpiryToNotify });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
