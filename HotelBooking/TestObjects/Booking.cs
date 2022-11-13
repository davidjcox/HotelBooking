using System;
using System.Collections.Generic;

using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

using HotelBooking.Utilities;
using System.Diagnostics.CodeAnalysis;


namespace HotelBooking.TestObjects
{
    public class Booking : IComparable, IComparable<Booking>, IEquatable<Booking>
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Decimal Price { get; set; }
        public bool Deposit { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string BookingId { get; set; }
        public static int PropertyCount { get; } = 6;


        public Booking()
        {
            //All Bookings must have a unique attribute to be hashable
            //Explicitly instantiated "reference" Bookings are assigned a negative BookingId to distinguish
            //from Bookings "retrieved" from the site which have positive BookingIds
            BookingId = new Random().Next(-99999, -11111).ToString();
        }

        public int CompareTo(Booking otherBooking)
        {
            if (object.ReferenceEquals(this, otherBooking))
                return 0;
            else if (otherBooking == null)
                return 1;
            
            //Comparable Bookings have identical Firstname and Surname, but remaining attributes may differ
            int comparable = this.Firstname.CompareTo(otherBooking.Firstname);
            
            if (comparable == 0)
            {
                comparable = this.Surname.CompareTo(otherBooking.Surname);
            }

            return comparable;
        }

        public int CompareTo(object obj)
        {
            //If object is wrong type or is null it can't be compared
            if (obj != null && obj.GetType() != GetType())
            {
                throw new ArgumentException($"Object must be of type {GetType()}");
            }

            return CompareTo(obj as Booking);
        }

        public bool Equals([AllowNull] Booking otherbooking)
        {
            //Equal Bookings have identical values for all attributes exposed by the Hotel booking form site
            return (otherbooking != null
                    && otherbooking.Firstname == this.Firstname
                    && otherbooking.Surname == this.Surname
                    && otherbooking.Price == this.Price
                    && otherbooking.Deposit == this.Deposit
                    && otherbooking.Checkin == this.Checkin
                    && otherbooking.Checkout == this.Checkout);
        }

        public override bool Equals(Object obj)
        {
            //If object which is not a Booking is null then return false
            if (obj == null) return false;

            //If other Booking object is null then return false, else check for equality
            Booking otherBooking = obj as Booking;
            if (otherBooking == null)
                return false;
            else
                return Equals(otherBooking);
        }

        public override int GetHashCode()
        {
            //Only the BookingId can be expected to be unique
            return this.BookingId.GetHashCode();
        }

        public static bool operator == (Booking booking1, Booking booking2)
        {
            //Two null objects are equal
            if (((object)booking1) == null || ((object)booking2) == null)
                return Object.Equals(booking1, booking2);

            //Otherwise check for equality
            return booking1.Equals(booking2);
        }

        public static bool operator != (Booking booking1, Booking booking2)
        {
            //If one or the other object is null then they are not equal
            if (((object)booking1) == null || ((object)booking2) == null)
                return ! Object.Equals(booking1, booking2);

            //Otherwise check for inequality
            return ! booking1.Equals(booking2);
        }

        public override string ToString()
        {
            return $"{Firstname}{Surname}";
        }
    }


    internal class BookingCheckinDateValueRetriever : DateTimeValueRetriever, IValueRetriever
    {
        /// <summary>
        /// Checks whether the CheckinDate property exists and can be retrieved.
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <param name="targetType"></param>
        /// <param name="propertyType"></param>
        /// <returns>bool</returns>
        bool IValueRetriever.CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return keyValuePair.Key.Equals("Checkin") && DateAndTime.TryParse(keyValuePair.Value, out _);
        }

        /// <summary>
        /// Retrieves the CheckinDate property. Since that property may be set using either a DateTime string or a
        /// specially-formatted day offset DateTime string, this custom retriever calls the GetNonEmptyValue method.
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <param name="targetType"></param>
        /// <param name="propertyType"></param>
        /// <returns>object</returns>
        object IValueRetriever.Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return GetNonEmptyValue(keyValuePair.Value);
        }

        /// <summary>
        /// Attempts to retrieve a DateTime string from either a parsed DateTime string or a parsed specially-formatted
        /// day offset DateTime string. If DateTime string parsing fails, DateTime.Today is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>DateTime</returns>
        protected override DateTime GetNonEmptyValue(string value)
        {
            _ = DateAndTime.TryParse(value, out DateTime dateTime);

            return dateTime.Date;
        }
    }

    internal class BookingCheckoutDateValueRetriever : DateTimeValueRetriever, IValueRetriever
    {
        /// <summary>
        /// Checks whether the CheckoutDate property exists and can be retrieved.
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <param name="targetType"></param>
        /// <param name="propertyType"></param>
        /// <returns>bool</returns>
        bool IValueRetriever.CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return keyValuePair.Key.Equals("Checkout") && DateAndTime.TryParse(keyValuePair.Value, out _);
        }

        /// <summary>
        /// Retrieves the CheckoutDate property. Since that property may be set using either a DateTime string or a
        /// specially-formatted day offset DateTime string, this custom retriever calls the GetNonEmptyValue method.
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <param name="targetType"></param>
        /// <param name="propertyType"></param>
        /// <returns>object</returns>
        object IValueRetriever.Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return GetNonEmptyValue(keyValuePair.Value);
        }

        /// <summary>
        /// Attempts to retrieve a DateTime string from either a parsed DateTime string or a parsed specially-formatted
        /// day offset DateTime string. If DateTime string parsing fails, DateTime.Today is returned.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>DateTime</returns>
        protected override DateTime GetNonEmptyValue(string value)
        {
            _ = DateAndTime.TryParse(value, out DateTime dateTime);

            return dateTime.Date;
        }
    }
}
