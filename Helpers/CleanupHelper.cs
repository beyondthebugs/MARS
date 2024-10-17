using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Mars.Helpers
{
    public static class CleanupHelper
    {
        // This method will delete all existing languages and skills before testing
        public static void CleanupLanguagesAndSkills(IWebDriver driver)
        {
            // Navigate to Languages and delete all present languages
            CleanupLanguages(driver);

            // Navigate to Skills and delete all present skills
            CleanupSkills(driver);
        }

        public static void CleanupLanguages(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Navigate to the Languages tab
            IWebElement languagesTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")));
            languagesTab.Click();

            // Loop until no languages are left to delete
            while (true)
            {
                try
                {
                    // Check if any language is still available
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));

                    // If no delete buttons are found, exit the loop
                    if (deleteButtons.Count == 0)
                    {
                        Console.WriteLine("No more languages to delete.");
                        break;
                    }

                    // Delete the first language in the list
                    IWebElement deleteButton = deleteButtons[0];
                    deleteButton.Click();
                    Console.WriteLine("Deleted a language.");

                    // Wait for a brief moment to let the deletion complete
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting language: {ex.Message}");
                    break;
                }
            }
        }

        public static void CleanupSkills(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Navigate to the Skills tab
            IWebElement skillsTab = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            skillsTab.Click();

            // Loop until no skills are left to delete
            while (true)
            {
                try
                {
                    // Check if any skill is still available
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));

                    // If no delete buttons are found, exit the loop
                    if (deleteButtons.Count == 0)
                    {
                        Console.WriteLine("No more skills to delete.");
                        break;
                    }

                    // Delete the first skill in the list
                    IWebElement deleteButton = deleteButtons[0];
                    deleteButton.Click();
                    Console.WriteLine("Deleted a skill.");

                    // Wait for a brief moment to let the deletion complete
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting skill: {ex.Message}");
                    break;
                }
            }
        }
    }
}
