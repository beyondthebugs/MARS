# MARS Automation Project
# DEMO - https://vimeo.com/1020470711

## Table of Contents
- [Project Overview](#project-overview)
- [Directory Structure](#directory-structure)
- [Setup Instructions](#setup-instructions)
- [Running the Tests](#running-the-tests)
- [Logging](#logging)
- [Environment Variables](#environment-variables)
- [Adding and Editing Test Scenarios](#adding-and-editing-test-scenarios)
- [Troubleshooting](#troubleshooting)

## Project Overview
The MARS Automation Project is designed to automate the testing of the MARS profile management system, focusing on the addition, editing, and deletion of languages and skills. This automation suite uses SpecFlow, Selenium WebDriver, and C# for test case execution, covering scenarios like login, adding languages, editing skills, and deleting entries from the user profile.

## Directory Structure
The project follows a clean and organized structure, dividing different functionalities into appropriate folders:
```
MARS/
│
├── Drivers/                # WebDriver initialization logic
│   └── WebDriverInitializer.cs
│
├── Features/               # Test scenarios written in SpecFlow (BDD)
│   └── LanguageAndSkills.feature
│
├── Helpers/                # Utility classes for shared logic
│   ├── AuthenticationHelper.cs    # Manages login/logout functionality
│   ├── CleanupHelper.cs           # Cleans up previous languages and skills
│   └── Logger.cs                  # Manages logging for the automation suite
│
├── Steps/                  # Step definitions for the BDD scenarios
│   └── LanguageAndSkillsSteps.cs  # Step implementation for Language and Skills management
│
├── Tests/                  # Test case scenarios in Excel format
│   └── LanguageAndSkills_TestCaseScenarios.xlsx
│
├── .env                    # Environment variables for secure login credentials
├── Program.cs              # Main entry point of the automation suite
├── README.md               # Project documentation
```

## Setup Instructions

### Prerequisites
Before running the tests, ensure the following are installed:
1. **Visual Studio 2022** or later.
2. **.NET SDK** (version 8.0 or higher).
3. **Chrome Browser** (the tests are configured to run using ChromeDriver).
4. **ChromeDriver** should match your Chrome version. The project is configured to manage ChromeDriver version automatically through `WebDriverManager`.

### Steps to Set Up the Project

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/
    cd mars-automation
    ```

2. **Open the Solution in Visual Studio**:
   Open the `.sln` file in Visual Studio 2022 or later.

3. **Install Required NuGet Packages**:
   In Visual Studio, right-click on the solution and choose `Restore NuGet Packages`. This will install all the required dependencies, including:
   - Selenium.WebDriver
   - SpecFlow
   - dotenv.net
   - ChromeDriver

4. **Set Up the `.env` File for Environment Variables**:
   A `.env` file is required to store your login credentials securely.
   - The `.env` file should be placed in the root of the project directory.
   - The contents of the `.env` file should be:
     ```bash
     MARS_USERNAME=your-email@example.com
     MARS_PASSWORD=your-password
     ```

5. **Build the Solution**:
   Press `Ctrl+Shift+B` or click on `Build > Build Solution`.

6. **Set ChromeDriver Version**:
   Ensure that the ChromeDriver version matches the version of the Chrome browser installed on your machine. The project uses the `WebDriverManager` to manage this automatically, so no manual configuration should be required unless specific issues arise.

## Running the Tests

### Running the Tests from Visual Studio
1. **Start the Test Suite**:
   - Open `Program.cs` and set it as the startup project.
   - Press `F5` or click on `Start` to execute the test suite. This will trigger the automated login, cleanup tasks, and execution of all language and skill scenarios.

2. **Test Execution Flow**:
   - **Login**: The system logs in using credentials from the `.env` file.
   - **Cleanup**: Any existing languages and skills in the profile will be removed before the new test scenarios start.
   - **Languages & Skills**: The system will add, edit, and delete languages and skills as per the test scenarios outlined in `LanguageAndSkills.feature`.

### Running the Tests via Command Line
You can also execute the tests using the .NET CLI:
```bash
dotnet run
```

## Logging
The automation suite includes a logging mechanism that stores test run details in the `Logs` directory. Each test run generates a log file (`TestLog.txt`) that captures:
- Login attempts
- Cleanup tasks
- Step-by-step actions for language and skill tests
- Any errors or exceptions encountered during the test execution

## Environment Variables

The `.env` file is used to securely store environment-specific data, such as login credentials:
- `MARS_USERNAME`: Your MARS portal login email.
- `MARS_PASSWORD`: Your MARS portal password.

The project uses the `dotenv.net` package to load environment variables.

## Adding and Editing Test Scenarios

1. **Modifying Scenarios**:
   - Test scenarios are defined in the `LanguageAndSkills.feature` file using Gherkin syntax.
   - Each scenario corresponds to a test case (e.g., adding, editing, deleting languages and skills).

2. **Step Definitions**:
   - The actual code implementation for each step is located in the `LanguageAndSkillsSteps.cs` file under the `Steps/` directory.

## Troubleshooting

### Common Issues
- **ChromeDriver Version Mismatch**: Ensure that the version of ChromeDriver matches the installed version of Chrome.
- **Missing Environment Variables**: If you see the error `Login credentials are not set in the .env file`, ensure that the `.env` file is correctly placed in the project root and that it contains valid credentials.
- **Port Conflicts (Docker)**: If Docker services are running and conflicts arise, ensure ports are not being used by other services. Stop conflicting services or update the Docker port configuration.