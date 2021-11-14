namespace NIDN.PatternMatching.Helpers;

public static class DateOnlyExtensions
{
    public static TimeSpan Subtract(this DateOnly d1, DateOnly d2)
    {
        return TimeSpan.FromDays(d1.DayNumber - d2.DayNumber);
    }

    public static DateOnly CurrentDateLocal()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }

    public static DateOnly CurrentDateUtc()
    {
        return DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
