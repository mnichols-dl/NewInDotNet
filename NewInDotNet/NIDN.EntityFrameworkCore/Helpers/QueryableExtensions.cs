namespace NIDN.EntityFrameworkCore.Helpers;

public static class QueryableExtensions
{
    public static IQueryable<TemporalRecord<T>> AsTemporalRecord<T>(this IQueryable<T> queryable, bool orderedByPeriodStartAscending = false,
        string periodStartColumnName = "PeriodStart", string periodEndColumnName = "PeriodEnd")
    {
        if (orderedByPeriodStartAscending)
        {
            queryable = queryable.OrderBy(x => EF.Property<DateTime>(x, periodStartColumnName));
        }

        return queryable
            .Select(x => new TemporalRecord<T>(x, EF.Property<DateTime>(x, periodStartColumnName),
            EF.Property<DateTime>(x, periodEndColumnName)));
    }
}

public class TemporalRecord<T>
{
    public T Record { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }

    public TemporalRecord(T @record, DateTime periodStart, DateTime periodEnd)
    {
        Record = record;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }
}
