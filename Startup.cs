using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Btec_Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Place ConfigureServices within the Startup class
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();

            // Registering AppDbContext with dependency injection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Other service configurations...
        }

        // Other methods, such as Configure, can also be here
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuration for the app during startup
        }

    }
}
