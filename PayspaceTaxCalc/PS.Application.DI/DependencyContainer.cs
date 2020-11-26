using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PS.Contracts.Logging;
using PS.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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

        public static void ConfigureLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILogManager, Logger>();
        }
    }
}
