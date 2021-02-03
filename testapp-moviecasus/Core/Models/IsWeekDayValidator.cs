using System;

namespace Core.Models
{
    public static class IsWeekDayValidator
    {
        public static bool IsWeekDay(this DateTime dateTime)
            => (int)dateTime.DayOfWeek >= 1 && (int)dateTime.DayOfWeek <= 4;
    }
}
