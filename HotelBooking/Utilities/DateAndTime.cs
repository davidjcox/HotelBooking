using System;


namespace HotelBooking.Utilities
{
    internal static class DateAndTime
    {
        /// <summary>
        /// Attempts to parse a string and to convert it into a DateTime. The passed string can either be in the form 
        /// of a DateTime string or in the form of a specially formatted string that represents a number of days offset
        /// from today, either positive or negative.
        /// If parsing of a DateTime string succeeds, True will be returned and the corresponding DateTime value will 
        /// be passed out.
        /// If parsing of a specially-formatted day offset string succeeds, True will be returned and the value of
        /// DateTime.Today +/- the days affset will be passed out.
        /// If parsing fails, False will be returned and DateTime.Today will be passed out.
        /// </summary>
        /// <param name="possibleDateTime"></param>
        /// <param name="value"></param>
        /// <returns>bool and DateTime</returns>
        public static bool TryParse(string possibleDateTime, out DateTime value)
        {
            DateTime dateTime;

            //If a DateTime is passed, try to parse it and return the result/value
            if (DateTime.TryParse(possibleDateTime, out dateTime))
            {
                value = dateTime;
                return true;
            }

            try
            {
                string[] possibleDateTimeComponents = possibleDateTime.Split('_');

                //If a specially-formatted day offset string is passed, try to parse it and return the result/value
                if ((possibleDateTimeComponents[0] == "today")
                    && (int.TryParse(possibleDateTimeComponents[1], out _))
                    && (possibleDateTimeComponents[2] == "days"))
                {
                    //Try to parse the days offset string into a DateTime + number of days the offset represents
                    if (int.TryParse(possibleDateTimeComponents[1], out int dateTimeOffset))
                    {
                        value = DateTime.Now.AddDays(dateTimeOffset);
                        return true;
                    }
                }

                //If either parsing attempt fails, just return today
                value = DateTime.Today;
                return false;
            }
            catch
            {
                //If any exception occurs, just return today
                value = DateTime.Today;
                return false;
            }
        }
    }
}
