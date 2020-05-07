using System;

namespace MOTReminder.Utils
{
    public interface IRegistrationHelper
    {
        DateTime ToUniversal(DateTime localDateTime);
        DateTime ToRemindingTime(DateTime dateTime);
        string ToRegistrationNumber(string regNumber);
        int DaysBeforeExpiryToNotify { get; }
    }
}
