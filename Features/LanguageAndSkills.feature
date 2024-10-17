Feature: Manage Languages and Skills on MARS Profile
  As a user, I want to log in, add, edit, delete languages and skills so that I can showcase my expertise on my profile.

  Background:
    Given I am on the MARS login page

  # Login Scenarios
  Scenario: TC01 - Login with valid credentials
    When I enter valid login credentials
    And I click the login button
    Then I should be redirected to the profile page

  Scenario: TC02 - Login with invalid credentials
    When I enter invalid login credentials
    And I click the login button
    Then an error message should be displayed for invalid credentials

  Scenario: TC03 - Logout from MARS portal
    Given I am logged into the MARS portal
    When I click the "Sign Out" button in the top-right corner
    Then I should be logged out and redirected to the login page

  # Language Scenarios
  Scenario: TC04 - Add four new languages
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I add a new language "English" with level "Fluent"
    And I add a new language "Tamil" with level "Conversational"
    And I add a new language "French" with level "Basic"
    And I add a new language "Malayalam" with level "Native/Bilingual"
    Then I should see the 'Add New' button disappear after the fourth language

  Scenario: TC05 - Edit French to Hindi and update level
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I edit the language "French" to "Hindi" with level "Fluent"
    Then the language "Hindi" with level "Fluent" should be displayed on my profile

  Scenario: TC06 - Add an existing language
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I try to add a duplicate language "English"
    Then I should hit cancel when a duplicate language is detected

  Scenario: TC07 - Edit language to another existing language
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I try to edit the language "Tamil" to "Hindi"
    Then I should hit cancel when a duplicate language is detected

  Scenario: TC08 - Delete a language
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I delete the language "Hindi"
    Then the language "Hindi" should no longer be displayed on my profile

  Scenario: TC09 - Verify Add New button is gone
    Given I am logged into the MARS portal
    When I navigate to the languages tab
    And I add four languages
    Then the 'Add New' button should no longer be visible after adding four languages

  # Skill Scenarios
  Scenario: TC10 - Add multiple new skills
    Given I am logged into the MARS portal
    When I navigate to the skills tab
    And I add a new skill "Python" with level "Expert"
    And I add a new skill "Tableau" with level "Intermediate"
    And I add a new skill "Power BI" with level "Beginner"
    And I add a new skill "R Programming" with level "Intermediate"
    And I add a new skill "SAS" with level "Expert"
    And I add a new skill "Excel" with level "Expert"
    And I add a new skill "Java" with level "Intermediate"
    Then the newly added skills should be displayed on my profile

  Scenario: TC11 - Edit skill "Power BI" to "SQL"
    Given I am logged into the MARS portal
    When I navigate to the skills tab
    And I edit the skill "Power BI" to "SQL" with level "Expert"
    Then the skill "SQL" with level "Expert" should be displayed on my profile

  Scenario: TC12 - Add an existing skill
    Given I am logged into the MARS portal
    When I navigate to the skills tab
    And I try to add a duplicate skill "Python"
    Then I should hit cancel when a duplicate skill is detected

  Scenario: TC13 - Edit skill to another existing skill
    Given I am logged into the MARS portal
    When I navigate to the skills tab
    And I try to edit the skill "SQL" to "Python"
    Then I should hit cancel when a duplicate skill is detected

  Scenario: TC14 - Delete a skill
    Given I am logged into the MARS portal
    When I navigate to the skills tab
    And I delete the skill "SQL"
    Then the skill "SQL" should no longer be displayed on my profile
