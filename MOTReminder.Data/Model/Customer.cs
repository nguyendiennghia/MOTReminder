using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MOTReminder.Data.Model
{
    public class Customer
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
