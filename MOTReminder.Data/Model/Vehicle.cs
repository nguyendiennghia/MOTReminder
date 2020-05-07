using System;
using System.Collections.Generic;
using System.Text;

namespace MOTReminder.Data.Model
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string RegNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Spec { get; set; }
        public DateTime MOTExpiry { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
