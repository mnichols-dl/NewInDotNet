using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace NIDN.MinimalApi;

public class HealthService
{
    public HealthStatus GetHealth()
    {
        var timeOfDay = TimeOnly.FromDateTime(DateTime.Now);
        if (timeOfDay < new TimeOnly(6, 0, 0))
        {
            return HealthStatus.Unhealthy;
        }
        return HealthStatus.Healthy;
    }
}
