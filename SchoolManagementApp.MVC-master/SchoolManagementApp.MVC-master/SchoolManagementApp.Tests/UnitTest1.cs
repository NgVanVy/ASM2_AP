using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolManagementApp.MVC.Controllers;
using SchoolManagementApp.MVC.Data;
using SchoolManagementApp.MVC.Models;

namespace SchoolManagementApp.Tests
{
    public class EnrollmentsControllerTests
    {
        private SchoolManagementDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<SchoolManagementDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // To ensure a fresh DB each time
                .Options;
            var context = new SchoolManagementDbContext(options);
            context.Database.EnsureDeleted(); // Ensure the DB is clean before creating a new one
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfEnrollments()
        {
            // Arrange
            using var context = GetDatabaseContext(); // Ensures that the context is disposed of at the end of the test
            var controller = new EnrollmentsController(context);

            // Optionally seed the in-memory database with test data
            context.Enrollments.AddRange(
                new Enrollment { StudentId = 1, ClassId = 1, Grade = "A" },
                new Enrollment { StudentId = 2, ClassId = 1, Grade = "B" }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Enrollment>>(viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.NotEmpty(model); // Expecting the seeded test data to be present
        }
    }
}