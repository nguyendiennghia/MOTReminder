using MOTReminder.Utils.RegistrationFormatter;
using System.ComponentModel.DataAnnotations;

namespace MOTReminder.Utils.Attribute
{
    public class RegNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formatter = (IRegistrationFormatter) validationContext.GetService(typeof(IRegistrationFormatter));
            var regNo = value?.ToString() ?? string.Empty;
            return formatter.IsValid(regNo) ? ValidationResult.Success : new ValidationResult("It must be registration format");
        }
    }
}
