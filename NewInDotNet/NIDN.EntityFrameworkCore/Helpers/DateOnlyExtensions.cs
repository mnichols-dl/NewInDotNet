namespace NIDN.EntityFrameworkCore.Helpers;

public static class DateOnlyExtensions
{
    public static TimeSpan Subtract(this DateOnly d1, DateOnly d2)
    {
        return d1.ToDateTime(TimeOnly.MinValue) - d2.ToDateTime(TimeOnly.MinValue);
    }
}
