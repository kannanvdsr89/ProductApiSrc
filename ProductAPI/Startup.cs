using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProductAPI.ContextMiddleware;
using ProductAPI.Services;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.File;

namespace ProductAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;           
        }
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddScoped<IProductDetailsService, ProductDetailsService>();
            services.AddDbContext<ProductDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlReaderDB")));
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    
    public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            //Swagger for all environment
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            
            app.Run();
        }

       
    }
}
