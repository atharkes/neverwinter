using System;

namespace DatabaseInterface {
    /// <summary> Static class with random useful methods </summary>
    internal static class Util {
        /// <summary> Create a sqlite string from a datetime </summary>
        /// <param name="dateTime">The datetime to create the string from</param>
        /// <returns>The created string</returns>
        public static string DateTimeSQLite(DateTime dateTime) {
            const string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat,
            dateTime.Year.ToString().PadLeft(4, '0'),
            dateTime.Month.ToString().PadLeft(2, '0'),
            dateTime.Day.ToString().PadLeft(2, '0'),
            dateTime.Hour.ToString().PadLeft(2, '0'),
            dateTime.Minute.ToString().PadLeft(2, '0'),
            dateTime.Second.ToString().PadLeft(2, '0'),
            dateTime.Millisecond.ToString().PadLeft(4, '0'));
        }
    }
}
