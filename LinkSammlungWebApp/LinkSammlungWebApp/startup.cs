using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LinkSammlungWebApp
{
    public class startup
    {
        
 // Other configurations

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:7149")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Other services
        }

        public void Configure(IApplicationBuilder app)
        {
            // Other configurations

            app.UseCors(); // Enable CORS for all requests

            // Other middleware and routing configurations
        }
    }

}
