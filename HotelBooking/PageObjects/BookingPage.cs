using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using HotelBooking.TestObjects;
using HotelBooking.Utilities;


namespace HotelBooking.PageObjects
{
    public class BookingPage : BasePage
    {
        public BookingPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        internal readonly By pageSentinel = By.TagName(@"h1");
        internal readonly By bookingRow = By.XPath(@"//div[@id='bookings']//div[@class='row']");
        internal readonly By bookingPropertyName = By.TagName(@"h3");
        internal readonly By bookingPropertyValue = By.TagName(@"p");
        internal readonly By firstNameInput = By.Id(@"firstname");
        internal readonly By lastNameInput = By.Id(@"lastname");
        internal readonly By totalPriceInput = By.Id(@"totalprice");
        internal readonly By depositPaidSelector = By.Id(@"depositpaid");
        internal readonly By checkInDatepicker = By.Id(@"checkin");
        internal readonly By checkOutDatepicker = By.Id(@"checkout");
        internal readonly By deleteButton = By.TagName(@"input");
        internal readonly By saveButton = By.XPath(@"//input[@value=' Save ']");


        /// <summary>
        /// Gets all Hotel booking form bookings, if bookings exist, otherwise returns null. 
        /// </summary>
        /// <returns>List<Booking> or null</Booking></returns>
        internal List<Booking> GetBookings()
        {
            ReadOnlyCollection<IWebElement> bookingRows = GetVisibleWebElements(bookingRow);
            ReadOnlyCollection<IWebElement> propertyNames = GetVisibleWebElements(bookingPropertyName, bookingRows[0]);
            List<Booking> bookings = new List<Booking>();

            //Start indexing at 1 to skip the header row
            for (int row = 1; row < bookingRows.Count; row++)
            {
                Booking booking = new Booking();

                //Only the first div in the booking row has an 'id' attribute
                booking.BookingId = bookingRows[row].GetDomAttribute("id");

                //Get the value of the current property
                ReadOnlyCollection<IWebElement> propertyValues = GetVisibleWebElements(bookingPropertyValue, bookingRows[row]);

                string[] charactersToRemove = { "-" };

                //Iterate all booking property divs, except the last which is the Delete button, to get their values
                for (int property = 0; property < Booking.PropertyCount; property++)
                {                    
                    //Remove the dash from the Check-in and Check-out headers so they match the attribute names
                    string propertyName = StringHandling.Sanitize(propertyNames[property].Text, charactersToRemove);

                    string propertyValue = propertyValues[property].Text;

                    //Identify a booking object property by current property name and try to set its value to the new booking object
                    switch (Type.GetTypeCode(booking.GetType().GetProperty(propertyName)?.PropertyType))
                    {
                        case TypeCode.Decimal:
                            if (Decimal.TryParse(propertyValue, out Decimal DecimalPropertyValue))
                            {
                                booking.GetType().GetProperty(propertyName)?.GetSetMethod()?.Invoke(booking, new object[] { DecimalPropertyValue });
                            }
                            else
                            {
                                throw new ArgumentException("Unparseable Decimal attribute.");
                            }
                            break;
                        case TypeCode.Boolean:
                            if (Boolean.TryParse(propertyValue, out bool BooleanPropertyValue))
                            {
                                booking.GetType().GetProperty(propertyName)?.GetSetMethod()?.Invoke(booking, new object[] { BooleanPropertyValue });
                            }
                            else
                            {
                                throw new ArgumentException("Unparseable Boolean attribute.");
                            }
                            break;
                        case TypeCode.DateTime:
                            if (DateTime.TryParse(propertyValue, out DateTime DateTimePropertyValue))
                            {
                                booking.GetType().GetProperty(propertyName)?.GetSetMethod()?.Invoke(booking, new object[] { DateTimePropertyValue.Date });
                            }
                            else
                            {
                                throw new ArgumentException("Unparseable DateTime attribute.");
                            }
                            break;
                        default:
                            booking.GetType().GetProperty(propertyName)?.GetSetMethod()?.Invoke(booking, new object[] { propertyValue });
                            break;
                    }
                }

                bookings.Add(booking);
            }

            return bookings.Count > 0 ? bookings : null;
        }

        /// <summary>
        /// Searches Hotel booking form bookings for all bookings comparable to target booking, if they exist, otherwise
        /// returns null.
        /// </summary>
        /// <param name="targetBooking"></param>
        /// <returns>List<Booking> or null</Booking></returns>
        internal List<Booking> GetComparableBookings(Booking targetBooking)
        {
            List<Booking> retrievedBookings = GetBookings();
            List<Booking> foundComparableBookings = new List<Booking>();

            if (retrievedBookings != null)
            {
                foreach (Booking retrievedBooking in retrievedBookings)
                {
                    if (retrievedBooking.CompareTo(targetBooking) == 0)
                    {
                        foundComparableBookings.Add(retrievedBooking);
                    }
                }
            }

            return foundComparableBookings.Count > 0 ? foundComparableBookings : null;
        }

        /// <summary>
        /// Searches Hotel booking form bookings for a booking equal to target booking, if it exists, otherwise
        /// returns null.
        /// </summary>
        /// <param name="targetBooking"></param>
        /// <returns>Booking or null</returns>
        internal Booking GetEqualBooking(Booking targetBooking)
        {
            List<Booking> retrievedBookings = GetBookings();
            List<Booking> foundEqualBookings = new List<Booking>();

            if (retrievedBookings != null)
            {
                foreach (Booking retrievedBooking in retrievedBookings)
                {
                    if (retrievedBooking == targetBooking)
                    {
                        foundEqualBookings.Add(retrievedBooking);
                    }
                }
            }

            return foundEqualBookings.Count == 1 ? foundEqualBookings[0] : null;
        }

        /// <summary>
        /// Delete any Hotel booking form booking created intentionally or unintentionally.
        /// </summary>
        /// <param name="referenceBookings"></param>
        internal void CleanUpBookingForm(List<Booking> referenceBookings)
        {
            List<Booking> comparableBookings = new List<Booking>();
            
            foreach(Booking referenceBooking in referenceBookings)
            {
                comparableBookings = GetComparableBookings(referenceBooking);

                if (comparableBookings != null)
                {
                    foreach (Booking comparableBooking in comparableBookings)
                    {
                        DeleteBooking(comparableBooking);
                    }
                }
            }
        }

        /// <summary>
        /// Create a new Hotel Booking form booking in the form of the booking object passed.
        /// </summary>
        /// <param name="referenceBooking"></param>
        internal void CreateBooking(Booking referenceBooking)
        {
            List<Booking> comparableBookings = GetComparableBookings(referenceBooking);
            int initialBookingCount = comparableBookings != null ? comparableBookings.Count : 0;
            int finalBookingCount = initialBookingCount;

            ClickBookingSaveButton();

            while (initialBookingCount == finalBookingCount)
            {
                comparableBookings = GetComparableBookings(referenceBooking);
                finalBookingCount = comparableBookings != null ? comparableBookings.Count : 0;
            }
        }

        /// <summary>
        /// Delete the Hotel booking form booking that corresponds to the booking object passed.
        /// </summary>
        /// <param name="createdBooking"></param>
        internal void DeleteBooking(Booking createdBooking)
        {
            By bookingId = By.Id(createdBooking.BookingId);
            IWebElement bookingToDelete = GetVisibleWebElement(bookingId); 

            if (bookingToDelete != null)
            {
                ClickBookingDeleteButton(bookingToDelete);

                WaitUntilElementNotPresent(bookingId);
            }
        }

        internal void SendKeysToFirstNameInput(string name)
        {
            IWebElement firstNameElement = GetVisibleWebElement(firstNameInput);

            SendKeysToElement(firstNameElement, name);
        }

        internal void SendKeysToLastNameInput(string name)
        {
            IWebElement lastNameElement = GetVisibleWebElement(lastNameInput);

            SendKeysToElement(lastNameElement, name);
        }

        internal void SendKeysToPriceInput(string price)
        {
            IWebElement totalPriceElement = GetVisibleWebElement(totalPriceInput);

            SendKeysToElement(totalPriceElement, price);
        }

        internal void SelectDepositPaidSelection(string choice)
        {
            SelectElement depositPaidSelectorElement = GetSelectElement(depositPaidSelector);

            depositPaidSelectorElement.SelectByText(choice);
        }

        internal void SendKeysToCheckinDatePicker(string checkinDateTime)
        {
            IWebElement checkinElement = GetVisibleWebElement(checkInDatepicker);

            SendKeysToElement(checkinElement, checkinDateTime);
        }

        internal void SendKeysToCheckoutDatePicker(string checkoutDateTime)
        {
            IWebElement checkoutElement = GetVisibleWebElement(checkOutDatepicker);

            SendKeysToElement(checkoutElement, checkoutDateTime);
        }

        internal void ClickBookingSaveButton()
        {
            IWebElement saveButtonElement = GetVisibleWebElement(saveButton);

            saveButtonElement.Click();
        }

        internal void ClickBookingDeleteButton(IWebElement booking)
        {
            IWebElement deleteButtonElement = booking.FindElement(deleteButton);

            deleteButtonElement.Click();
        }

        internal void ClickNeutralElement()
        {
            IWebElement neutralElement = GetVisibleWebElement(pageSentinel);

            neutralElement.Click();
        }
    }
}
