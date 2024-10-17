using dotenv.net;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public static class AuthenticationHelper
{
    static AuthenticationHelper()
    {
        // Load environment variables from the .env file
        DotEnv.Load();
        Console.WriteLine("Loaded environment variables from .env file.");
    }

    public static void Login(IWebDriver driver)
    {
        // Fetch the username and password from environment variables
        string username = Environment.GetEnvironmentVariable("MARS_USERNAME") ?? string.Empty;
        string password = Environment.GetEnvironmentVariable("MARS_PASSWORD") ?? string.Empty;

        // Debugging logs
        Console.WriteLine($"Fetched Username: {username}");
        Console.WriteLine($"Fetched Password: {(string.IsNullOrEmpty(password) ? "Password not set" : "Password loaded")}");

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new Exception("Login credentials are not set in the .env file or environment variables.");
        }

        driver.Navigate().GoToUrl("http://localhost:5000/Home");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='home']/div/div/div[1]/div/a"))).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email"))).SendKeys(username);
        driver.FindElement(By.Name("password")).SendKeys(password);
        driver.FindElement(By.XPath("//button[text()='Login']")).Click();
    }
}