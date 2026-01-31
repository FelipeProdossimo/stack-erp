using Microsoft.EntityFrameworkCore;
using StackErp.Infrastructure.Persistence;

namespace StackErp.Api.Endpoints;

public static class DiagnosticEndpoints
{
    public static void MapDiagnosticEndpoints(this WebApplication app)
    {
        app.MapGet("/diagnostic", async (StackErpDbContext context) =>
        {
            try
            {
                var canConnect = await context.Database.CanConnectAsync();
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
                var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();

                return Results.Ok(new
                {
                    timestamp = DateTime.UtcNow,
                    database = new
                    {
                        canConnect,
                        pendingMigrations = pendingMigrations.ToArray(),
                        appliedMigrations = appliedMigrations.ToArray()
                    }
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(
                    title: "Database Connection Failed",
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        });
    }
}