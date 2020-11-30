using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.Application.Services;
using PS.Contracts.Logging;
using PS.Contracts.Services;
using PS.Data.Context;
using PS.Infrastructure.Logging;

namespace PS.Application.DI
{
    public static class DependencyContainer
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIIS(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<TaxCalcDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void ConfigureLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILogManager, Logger>();
        }

        public static void ConfigureIoCServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculateTaxService, CalculateTaxService>();
        }
    }
}
