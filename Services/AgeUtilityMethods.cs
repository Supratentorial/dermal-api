using dermal.api.Interfaces;
using System;

namespace dermal.api.Services
{
    public class AgeUtilityMethods : IAgeUtilityMethods
    {
        public string GetAgeString(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int months = today.Month - birthDate.Month;
            int years = today.Year - birthDate.Year;

            if (today.Day < birthDate.Day)
            {
                months--;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            int days = (today - birthDate.AddMonths((years * 12) + months)).Days;
            if (years < 2)
            {
                return months + (months == 1 ? " month" : " months");
            }
            return years + (years == 1 ? " year" : " years");
        }
    }
}
