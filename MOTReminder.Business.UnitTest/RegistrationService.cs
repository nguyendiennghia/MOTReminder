using MOTReminder.Business.DTO;
using NUnit.Framework;
using FakeItEasy;
using System.Threading.Tasks;
using System;
using MOTReminder.Data;
using Microsoft.EntityFrameworkCore;
using MOTReminder.Utils;

namespace MOTReminder.Business.UnitTest
{
    [TestFixture]
    public class RegistrationService
    {
        private static Context SeedContext(Data.Model.Customer[] customers = null, Data.Model.Vehicle[] vehicles = null)
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "FakeDatabase" + Guid.NewGuid()).Options;
            var context = new Context(options);
            if (customers != null)
                context.Customers.AddRange(customers);
            if (vehicles != null)
                context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
            return context;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ProcessAsync_VehicleDetailsUpdated_SavesCustomerAndVehicle()
        {
            var regNumber = "KP62 RNN";
            var email = "ssgndn@gmail.com";
            var customer = new Customer
            {
                Email = email,
                Vehicles = new[] { new Vehicle { RegistrationNumber = regNumber } }
            };
            var expectedVehicle = new Vehicle
            {
                Make = "Suzuki",
                Manufacturer = "Suzuki",
                Model = "Kizashi",
                MOTExpiry = new DateTime(2020, 05, 30)
            };

            var vehicleService = A.Fake<IVehicleService>();
            A.CallTo(() => vehicleService.GetDetailsByAsync(regNumber)).Returns(Task.FromResult(expectedVehicle));

            var helper = A.Fake<IRegistrationHelper>();
            A.CallTo(() => helper.ToRegistrationNumber(regNumber)).Returns(regNumber);

            using var context = SeedContext();

            var service = new Business.RegistrationService(context, vehicleService, helper);
            await service.ProcessAsync(customer);

            A.CallTo(() => vehicleService.GetDetailsByAsync(regNumber)).MustHaveHappened();
            A.CallTo(() => helper.ToRegistrationNumber(regNumber)).MustHaveHappened();
            Assert.NotNull(customer?.Vehicles);
            Assert.AreEqual(1, customer.Vehicles.Count);
            var actualVehicle = customer.Vehicles[0];
            Assert.AreEqual(expectedVehicle, actualVehicle);
            Assert.AreEqual(1, await context.Vehicles.CountAsync());
            Assert.AreEqual(1, await context.Customers.CountAsync());
        }

        [Test]
        public async Task ProcessAsync_VehicleDetailsUpdated_DoesNotSaveCustomerAndVehicle()
        {
            var regNumber = "KP62 RNN";
            var email = "ssgndn@gmail.com";
            var customer = new Customer
            {
                Email = email,
                Vehicles = new[] { new Vehicle { RegistrationNumber = regNumber } }
            };
            var expectedVehicle = new Vehicle
            {
                Make = "Suzuki",
                Manufacturer = "Suzuki",
                Model = "Kizashi",
                MOTExpiry = new DateTime(2020, 05, 30),
                RegistrationNumber = regNumber
            };

            var vehicleService = A.Fake<IVehicleService>();
            A.CallTo(() => vehicleService.GetDetailsByAsync(regNumber)).Returns(Task.FromResult(expectedVehicle));

            var helper = A.Fake<IRegistrationHelper>();
            A.CallTo(() => helper.ToRegistrationNumber(regNumber)).Returns(regNumber);

            using var context = SeedContext(
                new[] { new Data.Model.Customer { Email = email } },
                new[] { new Data.Model.Vehicle { RegNo = regNumber } });

            var service = new Business.RegistrationService(context, vehicleService, helper);
            await service.ProcessAsync(customer);

            A.CallTo(() => vehicleService.GetDetailsByAsync(regNumber)).MustNotHaveHappened();
            A.CallTo(() => helper.ToRegistrationNumber(regNumber)).MustHaveHappened();
            Assert.NotNull(customer?.Vehicles);
            Assert.AreEqual(1, customer.Vehicles.Count);
            var actualVehicle = customer.Vehicles[0];
            Assert.AreEqual(expectedVehicle.RegistrationNumber, actualVehicle.RegistrationNumber);
            Assert.AreEqual(1, await context.Vehicles.CountAsync());
            Assert.AreEqual(1, await context.Customers.CountAsync());

        }
    }
}