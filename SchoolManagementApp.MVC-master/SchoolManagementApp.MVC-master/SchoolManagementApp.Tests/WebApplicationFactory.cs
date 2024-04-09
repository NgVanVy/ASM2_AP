using AspNetCoreHero.ToastNotification.Abstractions;
using Google.Apis.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SchoolManagementApp.MVC.Controllers;
using SchoolManagementApp.MVC.Data;
using SchoolManagementApp.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SchoolManagementApp.Tests
{

    public class EnrollmentsControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public EnrollmentsControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfEnrollments()
        {
            // Act
            var response = await _client.GetAsync("/Enrollments");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var enrollments = JsonConvert.DeserializeObject<IEnumerable<Enrollment>>(responseString);

            Assert.NotNull(enrollments);
            Assert.NotEmpty(enrollments);
        }

        [Fact]
        public async Task Details_ReturnsViewResult_ForEnrollment()
        {
            // Arrange
            // Assume the ID of the seeded Enrollment is 1
            var expectedEnrollmentId = 1;

            // Act
            var response = await _client.GetAsync($"/Enrollments/Index/{expectedEnrollmentId}");

            // Assert
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var enrollment = JsonConvert.DeserializeObject<Enrollment>(responseString);

            Assert.NotNull(enrollment);
            Assert.Equal(expectedEnrollmentId, enrollment.Id);
        }

        // Add other tests for Create, Edit, Delete, etc.

        // Be sure to implement the Dispose method if you need to clean up resources after each test.
    }

}