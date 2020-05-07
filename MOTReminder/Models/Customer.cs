using MOTReminder.Utils.Attribute;
using System.ComponentModel.DataAnnotations;

namespace MOTReminder.Models
{
    public class Customer
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegNumber]
        public string RegistrationNumber { get; set; }
    }
}
