using MOTReminder.Business.DTO;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MOTReminder.Business
{
    public class UKVDVehicleService : IVehicleService
    {
        private readonly static string _apiKey = "f750e3a3-fa25-4cb5-8da9-e46e31207175";
        private readonly static string _endpoint = 
            "https://uk1.ukvehicledata.co.uk/api/datapackage/VehicleAndMotHistory?v=2&api_nullitems=1&user_tag";
        private readonly IHttpClientFactory _client;

        public UKVDVehicleService(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<Vehicle> GetDetailsByAsync(string regNumber)
        {
            var apiUrl = $"{_endpoint}&auth_apikey={_apiKey}&key_VRM={regNumber}";
            var client = _client.CreateClient();
            client.BaseAddress = new Uri(apiUrl);
            var result = await client.GetStringAsync("");
            var resp = JsonSerializer.Deserialize<VehicleDataV2>(result)?.Response;
            if (resp == null)
                throw new InvalidOperationException(result);

            Vehicle vehicle = new Vehicle
            {
                RegistrationNumber = regNumber
            };
            if (resp.StatusCode == "Success")
            {
                vehicle.Manufacturer = resp.DataItems.ClassificationDetails.Smmt.Make;
                vehicle.Make = resp.DataItems.ClassificationDetails.Dvla.Make;
                vehicle.Model = resp.DataItems.ClassificationDetails.Dvla.Model;
                vehicle.MOTExpiry = DateTime.ParseExact(resp.DataItems.VehicleStatus.NextMotDueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            return vehicle;
        }
    }
}
