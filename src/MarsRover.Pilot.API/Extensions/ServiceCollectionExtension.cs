using MarsRover.Pilot.API.Application.Interfaces.Manager;
using MarsRover.Pilot.API.Application.Services.Manager;
using MarsRover.Pilot.API.Core.Integrations.Manager;
using MarsRover.Pilot.API.Core.Interfaces;
using MarsRover.Pilot.API.Core.Repositories.Manager;
using MarsRover.Pilot.API.Infrastructure.Context;
using MarsRover.Pilot.API.Infrastructure.Integrations.Manager;
using MarsRover.Pilot.API.Infrastructure.Logging;
using MarsRover.Pilot.API.Infrastructure.Repositories.Manager;

namespace MarsRover.Pilot.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCoreLayer(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddNewtonsoftJson();
        }

        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite()
                    .AddDbContext<RoverContext>();

            services.AddScoped(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IIntegrationManager, IntegrationManager>();
        }

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void AddWebLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }
    }
}