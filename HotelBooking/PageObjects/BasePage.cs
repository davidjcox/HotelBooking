using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace HotelBooking.PageObjects
{
    public abstract class BasePage
    {
        private protected IWebDriver _driver;
        private protected WebDriverWait _wait;
        

        public BasePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        /// <summary>
        /// Navigate to requested URL and attempt to wait until page finishes loading.
        /// </summary>
        /// <param name="url"></param>
        internal void NavigateTo(Uri url)
        {
            _driver.Navigate().GoToUrl(url);

            _driver.Manage().Window.FullScreen();
        }

        /// <summary>
        /// Determines whether expected page is loaded by comparing requested URL to actual.
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns>bool</returns>
        internal bool IsExpectedUrl(Uri pageUrl)
        {
            return _driver.Url.ToString().Equals(pageUrl.ToString());
        }

        /// <summary>
        /// Determines whether expected page is loaded by checking for presence of a sentinel element.
        /// </summary>
        /// <param name="pageSentinel"></param>
        /// <returns>bool</returns>
        internal bool IsExpectedPage(By pageSentinel)
        {
            return GetVisibleWebElement(pageSentinel).Displayed;
        }

        /// <summary>
        /// Waits until a web element is not attached to the DOM.
        /// </summary>
        /// <param name="byLocator"></param>
        internal void WaitUntilElementNotPresent(By byLocator)
        {
            _wait.Until(_driver => _driver.FindElements(byLocator).Count == 0);
        }

        /// <summary>
        /// Gets web element that is present and visible in the DOM.
        /// Wraps operation in .Net lambda wait instead of using Selenium ExpectedConditions,
        /// which has been deprecated and is currently unmaintained.
        /// </summary>
        /// <param name="byLocator"></param>
        /// <returns>WebElement or null</returns>
        internal IWebElement GetVisibleWebElement(By byLocator, IWebElement rootElement = null)
        {
            return _wait.Until<IWebElement>(_driver =>
            {
                IWebElement webElement = null;

                if (rootElement != null)
                {
                    webElement = rootElement.FindElement(byLocator);
                }
                else
                {
                    webElement = _driver.FindElement(byLocator);
                }

                return (webElement.Enabled && webElement.Displayed) ? webElement : null;
            });
        }

        /// <summary>
        /// Gets web elements that are present and visible in the DOM.
        /// Wraps operation in .Net lambda wait instead of using Selenium ExpectedConditions,
        /// which has been deprecated and is currently unmaintained.
        /// </summary>
        /// <param name="byLocator"></param>
        /// <returns>read-only collection of WebElements, or null</returns>
        internal ReadOnlyCollection<IWebElement> GetVisibleWebElements(By byLocator, IWebElement rootElement = null)
        {
            ReadOnlyCollection<IWebElement> webElements = null; 
            bool allWebElementsEnabledAndDisplayed = true;

            return _wait.Until<ReadOnlyCollection<IWebElement>>(_driver =>
            {
                if (rootElement != null)
                {
                    webElements = rootElement.FindElements(byLocator);
                }
                else
                {
                    webElements = _driver.FindElements(byLocator);
                }

                IEnumerator<IWebElement> webElementIterator = webElements.GetEnumerator();

                while (allWebElementsEnabledAndDisplayed && webElementIterator.MoveNext())
                {
                    if (!webElementIterator.Current.Enabled && !webElementIterator.Current.Displayed)
                    {
                        allWebElementsEnabledAndDisplayed = !allWebElementsEnabledAndDisplayed;
                    }
                }

                webElementIterator.Reset();

                return allWebElementsEnabledAndDisplayed ? webElements : null;
            });
        }

        /// <summary>
        /// Converts a web element into a selector, if possible.
        /// </summary>
        /// <param name="byLocator"></param>
        /// <returns>selector web element</returns>
        internal SelectElement GetSelectElement(By byLocator)
        {
            return new SelectElement(GetVisibleWebElement(byLocator)); ;
        }

        /// <summary>
        /// Clears input and sends text to it.
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="text"></param>
        internal void SendKeysToElement(IWebElement webElement, string text)
        {
            webElement.Clear();

            webElement.SendKeys(text);
        }
    }
}
