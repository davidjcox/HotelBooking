using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using HotelBooking.PageObjects;
using HotelBooking.TestObjects;
using HotelBooking.Utilities;


namespace HotelBooking.StepDefinitions
{
    [Binding]
    public class BookAHotelRoomSteps : IDisposable
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Uri _url;

        private ScenarioContext _scenarioContext;

        private BookingPage _bookingPage;

        private readonly uint _numberOfDuplicateBookings; 

        [Given(@"the user opens the Hotel booking form")]
        public void GivenTheUserOpensTheHotelBookingForm()
        {
            try
            {
                _bookingPage.NavigateTo(_url);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsTrue(_bookingPage.IsExpectedPage(_bookingPage.pageSentinel));
            Assert.IsTrue(_bookingPage.IsExpectedUrl(_url));
        }



        [When(@"the user creates a valid booking")]
        public void WhenTheUserCreatesAValidBooking(Table table)
        {
            Booking referenceBooking = table.CreateInstance<Booking>();

            try
            {
                _bookingPage.SendKeysToFirstNameInput(referenceBooking.Firstname);
                _bookingPage.SendKeysToLastNameInput(referenceBooking.Surname);
                _bookingPage.SendKeysToPriceInput(referenceBooking.Price.ToString());
                _bookingPage.SelectDepositPaidSelection(referenceBooking.Deposit.ToFormattedString());
                _bookingPage.SendKeysToCheckinDatePicker(referenceBooking.Checkin.ToFormattedString());
                _bookingPage.ClickNeutralElement();
                _bookingPage.SendKeysToCheckoutDatePicker(referenceBooking.Checkout.ToFormattedString());
                _bookingPage.ClickNeutralElement();
                _bookingPage.CreateBooking(referenceBooking);

                _scenarioContext.Add("Booking", referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }
        }


        [Then(@"the booking should be added to the booking listing")]
        public void ThenTheBookingShouldBeAddedToTheBookingListing()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            Booking createdBooking = new Booking();

            try
            {
                createdBooking = _bookingPage.GetEqualBooking(referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNotNull(createdBooking);
            Assert.AreEqual(createdBooking, referenceBooking);
            Assert.AreEqual(createdBooking.Firstname, referenceBooking.Firstname);
            Assert.AreEqual(createdBooking.Surname, referenceBooking.Surname);
            Assert.AreEqual(createdBooking.Price, referenceBooking.Price);
            Assert.GreaterOrEqual(createdBooking.Price, 0);
            Assert.AreEqual(createdBooking.Deposit, referenceBooking.Deposit);
            Assert.AreEqual(createdBooking.Checkin, referenceBooking.Checkin);
            Assert.AreEqual(createdBooking.Checkout, referenceBooking.Checkout);
            Assert.GreaterOrEqual(createdBooking.Checkout, createdBooking.Checkin);
        }


        [When(@"the user deletes that newly created booking")]
        public void WhenTheUserDeletesThatNewlyCreatedBooking()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            Booking createdBooking = new Booking();

            try
            {
                createdBooking = _bookingPage.GetEqualBooking(referenceBooking);

                _bookingPage.DeleteBooking(createdBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }
        }


        [Then(@"the newly-created booking should be removed from the booking listing")]
        public void ThenTheNewly_CreatedBookingShouldBeRemovedFromTheBookingListing()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            Booking createdBooking = new Booking();

            try
            {
                createdBooking = _bookingPage.GetEqualBooking(referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNull(createdBooking);
        }


        [When(@"the user creates multiple valid bookings")]
        public void WhenTheUserCreatesMultipleValidBookings(Table table)
        {
            IEnumerable<Booking> referenceBookings = table.CreateSet<Booking>();

            _scenarioContext.Add("firstBooking", referenceBookings.ElementAt(0));
            _scenarioContext.Add("midstBooking", referenceBookings.ElementAt(referenceBookings.Count<Booking>() / 2));
            _scenarioContext.Add("lastBooking", referenceBookings.ElementAt(referenceBookings.Count<Booking>() - 1));

            foreach (Booking referenceBooking in referenceBookings)
            {
                try
                {
                    _bookingPage.SendKeysToFirstNameInput(referenceBooking.Firstname);
                    _bookingPage.SendKeysToLastNameInput(referenceBooking.Surname);
                    _bookingPage.SendKeysToPriceInput(referenceBooking.Price.ToString());
                    _bookingPage.SelectDepositPaidSelection(referenceBooking.Deposit.ToFormattedString());
                    _bookingPage.SendKeysToCheckinDatePicker(referenceBooking.Checkin.ToFormattedString());
                    _bookingPage.ClickNeutralElement();
                    _bookingPage.SendKeysToCheckoutDatePicker(referenceBooking.Checkout.ToFormattedString());
                    _bookingPage.ClickNeutralElement();
                    _bookingPage.CreateBooking(referenceBooking);
                }
                catch (Exception exception)
                {
                    HandleRuntimeException(exception);
                }
            }
            _scenarioContext.Add("Bookings", referenceBookings);
        }
        
        
        [Then(@"all newly-created bookings should be added to the booking listing")]
        public void ThenAllNewly_CreatedBookingsShouldBeAddedToTheBookingListing()
        {
            IEnumerable<Booking> referenceBookings = (IEnumerable<Booking>)_scenarioContext["Bookings"];

            foreach (Booking referenceBooking in referenceBookings)
            {
                Booking createdBooking = new Booking();

                try
                {
                    createdBooking = _bookingPage.GetEqualBooking(referenceBooking);
                }
                catch (Exception exception)
                {
                    HandleRuntimeException(exception);
                }

                Assert.IsNotNull(createdBooking);
                Assert.AreEqual(createdBooking, referenceBooking);
                Assert.AreEqual(createdBooking.Firstname, referenceBooking.Firstname);
                Assert.AreEqual(createdBooking.Surname, referenceBooking.Surname);
                Assert.AreEqual(createdBooking.Price, referenceBooking.Price);
                Assert.GreaterOrEqual(createdBooking.Price, 0);
                Assert.AreEqual(createdBooking.Deposit, referenceBooking.Deposit);
                Assert.AreEqual(createdBooking.Checkin, referenceBooking.Checkin);
                Assert.AreEqual(createdBooking.Checkout, referenceBooking.Checkout);
                Assert.GreaterOrEqual(createdBooking.Checkout, createdBooking.Checkin);
            }
        }


        [When(@"the user deletes those newly-created valid bookings")]
        public void WhenTheUserDeletesThoseNewly_CreatedValidBookings()
        {
            IEnumerable<Booking> referenceBookings = (IEnumerable<Booking>)_scenarioContext["Bookings"];
            
            foreach (Booking referenceBooking in referenceBookings)
            {
                try
                {
                    Booking createdBooking = _bookingPage.GetEqualBooking(referenceBooking);
                    
                    _bookingPage.DeleteBooking(createdBooking);
                }
                catch (Exception exception)
                {
                    HandleRuntimeException(exception);
                }
            }
        }


        [Then(@"all newly-created bookings should be removed from the booking listing")]
        public void ThenAllNewly_CreatedBookingsShouldBeRemovedFromTheBookingListing()
        {
            IEnumerable<Booking> referenceBookings = (IEnumerable<Booking>)_scenarioContext["Bookings"];

            foreach (Booking referenceBooking in referenceBookings)
            {
                Booking createdBooking = new Booking();

                try
                {
                    createdBooking = _bookingPage.GetEqualBooking(referenceBooking);
                }
                catch (Exception exception)
                {
                    HandleRuntimeException(exception);
                }

                Assert.IsNull(createdBooking);
            }
        }


        [When(@"the user deletes the first booking of multiple newly-created bookings")]
        public void WhenTheUserDeletesTheFirstBookingOfMultipleNewly_CreatedBookings()
        {
            Booking firstReferenceBooking = (Booking)_scenarioContext["firstBooking"];
            Booking firstCreatedBooking = new Booking();

            try
            {
                firstCreatedBooking = _bookingPage.GetEqualBooking(firstReferenceBooking); 
                
                _bookingPage.DeleteBooking(firstCreatedBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }
        }


        [Then(@"the first booking of the multiple newly-created bookings should be removed from the booking listing")]
        public void ThenTheFirstBookingOfTheMultipleNewly_CreatedBookingsShouldBeRemovedFromTheBookingListing()
        {
            Booking firstReferenceBooking = (Booking)_scenarioContext["firstBooking"];
            Booking firstCreatedBooking = new Booking();

            try
            {
                firstCreatedBooking = _bookingPage.GetEqualBooking(firstReferenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNull(firstCreatedBooking);
        }


        [When(@"the user deletes one of the bookings in the midst of multiple newly-created bookings")]
        public void WhenTheUserDeletesOneOfTheBookingsInTheMidstOfMultipleNewly_CreatedBookings()
        {
            Booking midstReferenceBooking = (Booking)_scenarioContext["midstBooking"];
            Booking midstCreatedBooking = new Booking();

            try
            {
                midstCreatedBooking = _bookingPage.GetEqualBooking(midstReferenceBooking);

                _bookingPage.DeleteBooking(midstCreatedBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }
        }


        [Then(@"the booking in the midst of the multiple newly-created bookings should be removed from the booking listing")]
        public void ThenTheBookingInTheMidstOfTheMultipleNewly_CreatedBookingsShouldBeRemovedFromTheBookingListing()
        {
            Booking midstReferenceBooking = (Booking)_scenarioContext["midstBooking"];
            Booking midstCreatedBooking = new Booking();

            try
            {
                midstCreatedBooking = _bookingPage.GetEqualBooking(midstReferenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNull(midstCreatedBooking);
        }


        [When(@"the user deletes the last booking of multiple newly-created bookings")]
        public void WhenTheUserDeletesTheLastBookingOfMultipleNewly_CreatedBookings()
        {
            Booking lastReferenceBooking = (Booking)_scenarioContext["lastBooking"];
            Booking lastCreatedBooking = new Booking();

            try
            {
                lastCreatedBooking = _bookingPage.GetEqualBooking(lastReferenceBooking);

                _bookingPage.DeleteBooking(lastCreatedBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }
        }


        [Then(@"the last booking in the multiple newly-created bookings should be removed from the booking listing")]
        public void ThenTheLastBookingInTheMultipleNewly_CreatedBookingsShouldBeRemovedFromTheBookingListing()
        {
            Booking lastReferenceBooking = (Booking)_scenarioContext["lastBooking"];
            Booking lastCreatedBooking = new Booking();

            try
            {
                lastCreatedBooking = _bookingPage.GetEqualBooking(lastReferenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNull(lastCreatedBooking);
        }

        [When(@"the user creates multiple duplicate valid bookings")]
        public void WhenTheUserCreatesMultipleDuplicateValidBookings(Table table)
        {
            Booking referenceBooking = table.CreateInstance<Booking>();

            for (int duplicateBooking = 1; duplicateBooking <= _numberOfDuplicateBookings; duplicateBooking++)
            {
                try
                {
                    _bookingPage.SendKeysToFirstNameInput(referenceBooking.Firstname);
                    _bookingPage.SendKeysToLastNameInput(referenceBooking.Surname);
                    _bookingPage.SendKeysToPriceInput(referenceBooking.Price.ToString());
                    _bookingPage.SelectDepositPaidSelection(referenceBooking.Deposit.ToFormattedString());
                    _bookingPage.SendKeysToCheckinDatePicker(referenceBooking.Checkin.ToFormattedString());
                    _bookingPage.ClickNeutralElement();
                    _bookingPage.SendKeysToCheckoutDatePicker(referenceBooking.Checkout.ToFormattedString());
                    _bookingPage.ClickNeutralElement();
                    _bookingPage.CreateBooking(referenceBooking);
                }
                catch (Exception exception)
                {
                    HandleRuntimeException(exception);
                }
            }

            _scenarioContext.Add("Booking", referenceBooking);
        }

        [Then(@"all newly-created duplicate bookings should be added to the booking listing")]
        public void ThenAllNewly_CreatedDuplicateBookingsShouldBeAddedToTheBookingListing()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            List<Booking> createdBookings = new List<Booking>();

            try
            {
                createdBookings = _bookingPage.GetComparableBookings(referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            foreach (Booking createdBooking in createdBookings)
            {
                Assert.IsNotNull(createdBooking);
                Assert.AreEqual(createdBooking, referenceBooking);
                Assert.AreEqual(createdBooking.Firstname, referenceBooking.Firstname);
                Assert.AreEqual(createdBooking.Surname, referenceBooking.Surname);
                Assert.AreEqual(createdBooking.Price, referenceBooking.Price);
                Assert.GreaterOrEqual(createdBooking.Price, 0);
                Assert.AreEqual(createdBooking.Deposit, referenceBooking.Deposit);
                Assert.AreEqual(createdBooking.Checkin, referenceBooking.Checkin);
                Assert.AreEqual(createdBooking.Checkout, referenceBooking.Checkout);
                Assert.GreaterOrEqual(createdBooking.Checkout, createdBooking.Checkin);
            }
        }

        [When(@"the user deletes those newly-created duplicate valid bookings")]
        public void WhenTheUserDeletesThoseNewly_CreatedDuplicateValidBookings()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            List<Booking> createdBookings = new List<Booking>();

            try
            {
                createdBookings = _bookingPage.GetComparableBookings(referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            foreach (Booking createdBooking in createdBookings)
            {
                _bookingPage.DeleteBooking(createdBooking);
            }
        }

        [Then(@"all newly-created duplicate bookings should be removed from the booking listing")]
        public void ThenAllNewly_CreatedDuplicateBookingsShouldBeRemovedFromTheBookingListing()
        {
            Booking referenceBooking = (Booking)_scenarioContext["Booking"];
            List<Booking> createdBookings = new List<Booking>();

            try
            {
                createdBookings = _bookingPage.GetComparableBookings(referenceBooking);
            }
            catch (Exception exception)
            {
                HandleRuntimeException(exception);
            }

            Assert.IsNull(createdBookings);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new BookingCheckinDateValueRetriever());
            Service.Instance.ValueRetrievers.Register(new BookingCheckoutDateValueRetriever());
        }

        [BeforeFeature]
        public static void InitializeTestReport(FeatureContext _featureContext)
        {
            TestReport.InitializeTestReport();

            TestReport.CreateTest(_featureContext);
        }

        [BeforeScenario]
        public void AddScenarioToTest(ScenarioContext _scenarioContext)
        {
            TestReport.AddScenarioToTest(_scenarioContext);
        }

        [AfterStep]
        public void AddScenarioStepTestResultToTest(ScenarioContext _scenarioContext)
        {
            TestReport.AddScenarioStepToTest(_scenarioContext); 
            TestReport.AddScenarioStepTestResultToTest(_scenarioContext);
        }

        [AfterScenario]
        public void AddScenarioTestResultToTestAndCleanUpBookingForm(ScenarioContext _scenarioContext)
        {
            TestReport.AddTestResultToTest(_scenarioContext);

            if (_scenarioContext.ContainsKey("Booking"))
            {
                Booking referenceBooking = (Booking)_scenarioContext["Booking"];
                _bookingPage.CleanUpBookingForm(new List<Booking>() { referenceBooking });
            }
            
            if (_scenarioContext.ContainsKey("Bookings"))
            {
                List<Booking> referenceBookings = (List<Booking>)_scenarioContext["Bookings"];
                _bookingPage.CleanUpBookingForm(referenceBookings);
            }

            _scenarioContext.Clear();
        }

        [AfterFeature]
        public static void FinalizeTestReport()
        {
            TestReport.FinalizeTestReport();
        }

        private static void HandleRuntimeException(Exception exception)
        {
            TestReport.extentBDDTest.Log(AventStack.ExtentReports.Status.Error, exception);
            Console.WriteLine(exception);
        }

        public BookAHotelRoomSteps(FeatureContext featureContext,
            ScenarioContext scenarioContext,
            ScenarioInfo scenarioInfo)
        {
            var configuration = ProjectConfiguration.GetProjectConfiguration();

            _driver = WebDriverFactory.GetWebDriver(configuration["WebDriverType"]);

            if (double.TryParse(configuration["WaitTimeoutInSeconds"], out double waitTimeoutInSeconds))
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeoutInSeconds));
            }
            else
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            }

            _url = new Uri(configuration["TestUrl"]);

            if (uint.TryParse(configuration["NumberOfDuplicateBookings"], out uint numberOfDuplicateBookings))
            {
                _numberOfDuplicateBookings = numberOfDuplicateBookings;
            }
            else
            {
                _numberOfDuplicateBookings = 10;
            }

            _scenarioContext = scenarioContext;

            _bookingPage = new BookingPage(_driver, _wait);
        }


        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                
                _driver.Dispose();

                _driver = null;
            }
        }
    }
}
