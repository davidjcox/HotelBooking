

namespace HotelBooking.Utilities
{
    internal static class StringHandling
    {
        /// <summary>
        /// Strips the passed characters to remove from the passed string to be sanitized.
        /// </summary>
        /// <param name="stringToSanitize"></param>
        /// <param name="charactersToRemove"></param>
        /// <returns>string</returns>
        internal static string Sanitize(string stringToSanitize, string[] charactersToRemove)
        {
            string sanitizedString = string.Empty;
            
            foreach (string character in charactersToRemove)
            {
                sanitizedString = stringToSanitize.Replace(character, string.Empty);
            }

            return sanitizedString;
        }
    }
}
