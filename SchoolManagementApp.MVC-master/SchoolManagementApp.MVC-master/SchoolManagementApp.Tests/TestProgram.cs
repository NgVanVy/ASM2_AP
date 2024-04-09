using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SchoolManagementApp.Tests
{
    public class TestProgram
    {
        public static void TestMain(string[] args) // Rename Main to something else, like TestMain
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TestStartup>(); // Use a TestStartup class for the test environment
                });
    }
}
