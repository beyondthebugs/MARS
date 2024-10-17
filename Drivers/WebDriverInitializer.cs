// Initializes WebDriver

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Mars.Drivers
{
    public class WebDriverInitializer
    {
        public static IWebDriver Initialize()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
