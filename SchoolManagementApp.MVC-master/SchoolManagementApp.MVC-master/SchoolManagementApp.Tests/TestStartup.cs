using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagementApp.Tests
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services needed for testing, such as mocking or in-memory databases
            // Example:
            // services.AddScoped<IMyService, MockMyService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure middleware specific for testing, if needed
        }
    }
}