using System;
using System.Collections.Generic;
using System.Text;

namespace MOTReminder.Business.DTO
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public DateTime MOTExpiry { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
