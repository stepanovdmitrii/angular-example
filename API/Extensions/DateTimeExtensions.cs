using System;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dt){
            var today = DateTime.Today;
            var age = today.Year - dt.Year;
            if(dt.Date > today.AddYears(-age)){
                age--;
            }
            return age;
        }
    }
}