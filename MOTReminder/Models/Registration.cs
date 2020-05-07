namespace MOTReminder.Models
{
    public class Registration
    {
        public Business.DTO.Customer Customer { get; set; }
        public int DaysBeforeExpiry { get; set; }
    }
}
