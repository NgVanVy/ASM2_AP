using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SchoolManagementApp.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            _ = builder.ConfigureServices(services =>
            {
                // Specify that the database should use an in-memory provider for testing.
                services.AddScoped(serviceProvider =>
                {
                    // Create a new service provider that includes an in-memory database service.
                    var inMemoryServiceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    // Build a DbContextOptions object with in-memory options.
                    var options = new DbContextOptionsBuilder<SchoolManagementDbContext>()
                        .UseInMemoryDatabase("InMemorySchoolDbForTesting")
                        .UseInternalServiceProvider(inMemoryServiceProvider)
                        .Options;

                    // Create a new context for testing.
                    return new SchoolManagementDbContext(options);
                });

                // If you have other services that may require to be replaced or mocked for tests, configure them here.

                // Remove the app's SchoolManagementDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<SchoolManagementDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add the Auth0 services as they are configured in the actual application.
                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                    {"Auth0:Domain", "dev-8imyp1b3088nrbnh.us.auth0.com"}, // Replace with your Auth0 domain
                    {"Auth0:ClientId", "LODWe5ywphkWHktfYbdBLhLFapzBM0dS"}, // Replace with your Auth0 client ID
                    })
                    .Build();

                services
                    .AddAuth0WebAppAuthentication(options =>
                    {
                        options.Domain = configuration["Auth0:Domain"];
                        options.ClientId = configuration["Auth0:ClientId"];
                    });

                // Mock toast-notification service or abstract it away because UI-related features aren't relevant for API integration testing.
            });

            // In case you're altering anything from the configuration based on the environment, you can simulate it here.
            builder.ConfigureAppConfiguration((context, conf) =>
            {
                // conf.AddInMemoryCollection(new Dictionary<string, string>
                // {
                //     {"Key", "Value"} // Mock specific configuration settings if needed
                // });
            });
        }
    }
}
