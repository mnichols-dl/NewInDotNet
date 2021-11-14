using Microsoft.AspNetCore.Mvc;

namespace NIDN.MinimalApi.Endpoints;

public static class HealthCheck
{
    public static void AddHealthCheckEndpoint(this WebApplication app) => 
        app.MapGet("/healthcheck/{serviceName}", ([FromServices] HealthService healthService,
                [FromRoute] string serviceName) =>
            {

                return healthService.GetHealth();
            })
            .AllowAnonymous();
}
