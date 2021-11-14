namespace NIDN.DateOnlyTimeOnly.Helpers;

public static class TimeOnlyExtensions
{
    public static TimeOnly CurrentTimeLocal()
    {
        return TimeOnly.FromDateTime(DateTime.Today);
    }

    public static TimeOnly CurrentTimeUtc()
    {
        return TimeOnly.FromDateTime(DateTime.UtcNow);
    }
}
