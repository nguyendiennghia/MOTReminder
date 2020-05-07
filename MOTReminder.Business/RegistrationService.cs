using MOTReminder.Business.DTO;
using MOTReminder.Data;
using MOTReminder.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public class RegistrationService : IRegistrationService
    {
        private readonly Context _context;
        private readonly IVehicleService _vehicleService;
        private readonly IRegistrationHelper _helper;

        public RegistrationService(Context context, IVehicleService vehicleService, IRegistrationHelper helper)
        {
            _context = context;
            _vehicleService = vehicleService;
            _helper = helper;
        }

        private static Vehicle Map(Data.Model.Vehicle vehicle)
            => new Vehicle
            {
                RegistrationNumber = vehicle.RegNo,
                Manufacturer = vehicle.Make,
                Make = vehicle.Make,
                Model = vehicle.Model,
                MOTExpiry = vehicle.MOTExpiry
            };

        private Data.Model.Vehicle Map(Vehicle vehicle)
            => new Data.Model.Vehicle
            {
                Make = vehicle.Make,
                Model = vehicle.Model,
                RegNo = _helper.ToRegistrationNumber(vehicle.RegistrationNumber),
                MOTExpiry = _helper.ToUniversal(vehicle.MOTExpiry)
            };

        public async Task ProcessAsync(Customer customer)
        {
            var cust = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if (cust == null)
            {
                cust = new Data.Model.Customer { Email = customer.Email };
                _context.Customers.Add(cust);
            }

            var regNumbers = customer.Vehicles.Select(v => v.RegistrationNumber).Select(_helper.ToRegistrationNumber);
            var internalVehicles = _context.Vehicles
                .Where(v => regNumbers.Contains(v.RegNo))
                .Select(Map).ToArray();
            var internalRegNumbers = internalVehicles.Select(v => v.RegistrationNumber);
            var externalVehicles = regNumbers.Where(r => !internalRegNumbers.Contains(r))
                .Select(async r => await _vehicleService.GetDetailsByAsync(r))
                .Select(v => v.Result).ToList();

            foreach (var veh in externalVehicles)
            {
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.RegNo == veh.RegistrationNumber);
                if (vehicle == null)
                {
                    vehicle = Map(veh);
                    vehicle.Customer = cust;
                    _context.Vehicles.Add(vehicle);
                }
            }
            await _context.SaveChangesAsync();

            customer.Vehicles = internalVehicles.Union(externalVehicles).ToList();
        }
    }
}
