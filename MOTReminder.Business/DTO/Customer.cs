using System;
using System.Collections.Generic;
using System.Text;

namespace MOTReminder.Business.DTO
{
    public class Customer
    {
        public string Email { get; set; }

        public IList<Vehicle> Vehicles { get; set; }
    }
}
