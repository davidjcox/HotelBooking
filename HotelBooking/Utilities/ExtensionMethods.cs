using System;


namespace HotelBooking.Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns DateTime formatted specifically for test project needs.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static string ToFormattedString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Returns string formatted specifically for test project needs.
        /// </summary>
        /// <param name="boolean"></param>
        /// <returns></returns>
        public static string ToFormattedString(this bool boolean)
        {
            return boolean.ToString().ToLower();
        }
    }
}
