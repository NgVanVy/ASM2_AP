using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.MVC.Controllers;
using SchoolManagementApp.MVC.Data;

namespace SchoolManagement.Tests
{
    public class Tests
    {
        [TestFixture]
        public class ClassesControllerTests
        {
            private ClassesController _classesController;
            private Mock<SchoolManagementDbContext> _mockContext;
            private Mock<INotyfService> _mockNotyfService;

            [SetUp]
            public void SetUp()
            {
                // Initialize the mock context and mock notification service here
                _mockContext = new Mock<SchoolManagementDbContext>(new DbContextOptions<SchoolManagementDbContext>());
                _mockNotyfService = new Mock<INotyfService>();
                // Setup the Classes controller with mocked dependencies
                _classesController = new ClassesController(_mockContext.Object, _mockNotyfService.Object);
            }

            [Test]
            public async Task Details_WhenClassExists_ReturnsViewResultWithClass()
            {
                // Arrange
                int testClassId = 1; // assuming a class with ID 1 exists
                var testClass = new Class { Id = testClassId, LecturerId = 1, CourseId = 1, Time = DateTime.Now };
                _mockContext.Setup(c => c.Classes.FindAsync(testClassId)).ReturnsAsync(testClass);

                // Act
                var result = await _classesController.Details(testClassId) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
                var model = result.Model as Class;
                Assert.IsNotNull(model);
                Assert.AreEqual(testClassId, model.Id);
            }

            // Other tests would go here
        }
    }
}