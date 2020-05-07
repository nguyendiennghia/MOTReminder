using Hangfire;
using MOTReminder.Business.DTO;
using MOTReminder.Utils;
using NETCore.MailKit.Core;
using System;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public class MOTService : IMOTService
    {
        private readonly IRegistrationHelper _helper;
        private readonly IEmailService _emailService;

        public MOTService(IRegistrationHelper helper, IEmailService emailService)
        {
            _helper = helper;
            _emailService = emailService;
        }

        public async Task RemindByEmail(string email, Vehicle vehicle)
        {
            var remindAt = _helper.ToRemindingTime(vehicle.MOTExpiry);
            var gap = (remindAt - DateTime.Now).TotalSeconds;
            BackgroundJob.Schedule(() => 
                _emailService.Send(email, $"MOT Expiry of {vehicle.RegistrationNumber}: {vehicle.MOTExpiry}",
                    $"Dear customer,<br />" +
                    $"<br />" +
                    $"<h3>MOT of your vehicle {vehicle.RegistrationNumber} is going to expired soon in next {_helper.DaysBeforeExpiryToNotify} days!</h3>" +
                    $"<h4><i>MOT expiry: {vehicle.MOTExpiry}</i></h4>" +
                    $"<br />" +
                    $"Regards,<br />" +
                    $"VehicleMOT Team",
                    true),
                TimeSpan.FromSeconds(gap));
        }

        public async Task RemindBySMS(string phoneNumber, Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
