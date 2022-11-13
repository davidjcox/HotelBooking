using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.Helpers;
using WebDriverManager.DriverConfigs.Impl;


namespace HotelBooking.Utilities
{
    internal static class WebDriverFactory
    {
        internal static IWebDriver GetWebDriver(string webDriverType)
        {
            switch (webDriverType)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new ChromeDriver();
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig(), "Latest");
                    return new FirefoxDriver();
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new EdgeDriver();
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    return new ChromeDriver();
            }
        }
    }
}
