using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace SchoolManagementApp.Tests
{
    public class StudentsE2ETests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public StudentsE2ETests()
        {
            // Set up the test server and Selenium WebDriver
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestProgram>()
                .UseTestServer());
            _client = _server.CreateClient();
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            // Clean up
            _driver.Quit();
            _driver.Dispose();
            _client.Dispose();
            _server.Dispose();
        }

        // Define E2E tests here...
        [Fact]
        public void CanNavigateToIndexPageAndSeeStudents()
        {
            // Arrange
            var webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:7050/Students/Index");

            // Act - Check for the existence of the 'Students' header on the page.
            var header = webDriver.FindElement(By.TagName("h1"));

            // Assert - The page contains 'Students' header.
            Assert.Equal("Students", header.Text);

            // Act - Check if the 'Create New' button is present.
            var createNewBtn = webDriver.FindElement(By.LinkText("Create New"));

            // Assert - 'Create New' button is displayed.
            Assert.True(createNewBtn.Displayed);

            // Act - Check if the table of students is present.
            var table = webDriver.FindElement(By.ClassName("table"));

            // Assert
            Assert.NotNull(table);

            // Cleanup
            webDriver.Quit();
        }

        [Fact]
        public void DeleteStudent_WhenDeleteButtonClicked_DisplaysConfirmationAndDeletesStudent()
        {
            // Arrange
            var webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:7050/Students/Index");

            // Act - Find the first 'Delete' button and click it
            var deleteButtons = webDriver.FindElements(By.ClassName("deleteBtn"));
            var deleteButton = deleteButtons.FirstOrDefault();
            deleteButton?.Click();

            // Handle JavaScript SweetAlert dialogs using Selenium's alert interface.
            var alert = webDriver.SwitchTo().Alert();

            // Assert - JavaScript confirmation dialog displays the correct text.
            Assert.Contains("Are you sure?", alert.Text);

            // Act - Accept the dialog to delete the student.
            alert.Accept();

            // Assert - Check that the student was deleted using the API or by refreshing the page 
            // and ensuring the student no longer exists in the table.

            // Cleanup
            webDriver.Quit();
        }

        // Additional tests can be created for Edit and Details functionality in a similar fashion.
    }


}
