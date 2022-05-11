using MarsRover.Pilot.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MarsRover.Pilot.API.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            RoverContext db = scope.ServiceProvider.GetRequiredService<RoverContext>();
            db.Database.Migrate();
        }
    }
}