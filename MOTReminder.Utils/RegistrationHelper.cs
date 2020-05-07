using Microsoft.Extensions.Configuration;
using System;
using System.Text.RegularExpressions;

namespace MOTReminder.Utils
{
    public class RegistrationHelper : IRegistrationHelper
    {
        private IConfiguration _config;

        public RegistrationHelper(IConfiguration config)
        {
            _config = config;
        }

        public int DaysBeforeExpiryToNotify 
        {
            get
            {
                return _config?.GetSection("ExpiryReminder") != null &&
                    int.TryParse(_config?.GetSection("ExpiryReminder")["Before"], out int before)
                    ? before
                    : 30;
            }
        } 

        string IRegistrationHelper.ToRegistrationNumber(string regNumber)
            => Regex.Replace(regNumber, @"\s+", string.Empty);

        DateTime IRegistrationHelper.ToRemindingTime(DateTime dateTime)
            => dateTime.AddDays(-DaysBeforeExpiryToNotify);

        DateTime IRegistrationHelper.ToUniversal(DateTime localDateTime)
            => localDateTime.ToUniversalTime();
    }
}
