using OpenQA.Selenium;
using Mars.Drivers;
using Mars.Helpers;
using System;
using dotenv.net;

namespace Mars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Load environment variables from .env file
            DotEnv.Load();

            // Initialize WebDriver
            IWebDriver driver = WebDriverInitializer.Initialize();

            // Set up logging
            Logger.InitializeLogFile();

            // Perform login
            Logger.Log("Logging into MARS...");
            AuthenticationHelper.Login(driver);
            Logger.Log("User successfully logged in.");

            // Cleanup Task - Remove all existing languages and skills
            Logger.Log("Starting cleanup of existing languages and skills...");
            CleanupHelper.CleanupLanguagesAndSkills(driver);
            Logger.Log("Cleanup completed successfully.");

            // Handle Languages Section
            RunLanguageTests(driver);

            // Handle Skills Section
            RunSkillTests(driver);

            // Optionally quit the driver after the tests are done
            driver.Quit();

            // Final log message
            Logger.Log("Test suite completed successfully.");
        }

        public static void RunLanguageTests(IWebDriver driver)
        {
            LanguageSteps languageSteps = new LanguageSteps(driver);
            languageSteps.GoToLanguagesTab();

            // ** Basic Positive Tests **
            Logger.Log("\n[Running Basic Positive Language Tests]");
            languageSteps.AddNewLanguage("English", "Fluent");
            languageSteps.AddNewLanguage("Tamil", "Conversational");
            languageSteps.AddNewLanguage("French", "Basic");
            languageSteps.AddNewLanguage("Malayalam", "Native/Bilingual");
            languageSteps.VerifyAddNewButtonIsGone();

            // Edit language French to Hindi and change the level
            languageSteps.EditLanguage("French", "Hindi", "Fluent");

            // ** Extended Positive Testing with Optional Parameters **
            Logger.Log("\n[Running Extended Positive Language Tests]");
            languageSteps.EditLanguage("Tamil", "Kannada", "Conversational");
            languageSteps.EditLanguage("Malayalam", "Telugu", "Native/Bilingual");

            // ** Negative Testing with Valid Input **
            Logger.Log("\n[Running Negative Language Testing with Valid Input]");
            languageSteps.AddNewLanguage("English", "Fluent");

            // ** Destructive Testing **
            Logger.Log("\n[Running Destructive Language Testing]");
            languageSteps.HandleDuplicateLanguage("English");

            // ** Deleting Languages **
            Logger.Log("\n[Running Language Deletion Tests]");
            languageSteps.DeleteLanguage("Hindi");   // Delete a specific language
            languageSteps.DeleteLanguage("Kannada"); // Delete another one
        }

        public static void RunSkillTests(IWebDriver driver)
        {
            SkillSteps skillSteps = new SkillSteps(driver);
            skillSteps.GoToSkillsTab();

            // ** Basic Positive Tests **
            Logger.Log("\n[Running Basic Positive Skill Tests]");
            skillSteps.AddSkill("Python", "Expert");
            skillSteps.AddSkill("Tableau", "Intermediate");
            skillSteps.AddSkill("Power BI", "Beginner");
            skillSteps.AddSkill("R Programming", "Intermediate");
            skillSteps.AddSkill("SAS", "Expert");
            skillSteps.AddSkill("Excel", "Expert");
            skillSteps.AddSkill("Java", "Intermediate");

            // Edit the skill - change Power BI to SQL and update the level
            skillSteps.EditSkill("Power BI", "SQL", "Expert");

            // ** Negative Testing with Valid Input **
            Logger.Log("\n[Running Negative Skill Testing with Valid Input]");
            Logger.Log("Attempting to add duplicate skills...");
            skillSteps.AddSkill("Python", "Expert");

            // ** Destructive Testing **
            Logger.Log("\n[Running Destructive Skill Testing]");
            skillSteps.HandleDuplicateSkill("Python");

            // ** Deleting Skills **
            Logger.Log("\n[Running Skill Deletion Tests]");
            skillSteps.DeleteSkill("SQL");     // Delete a specific skill
            skillSteps.DeleteSkill("Java");    // Delete another one
        }
    }
}