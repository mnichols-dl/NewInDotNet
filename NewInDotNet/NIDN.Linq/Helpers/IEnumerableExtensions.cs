namespace NIDN.Linq.Helpers;

public static class IEnumerableExtensions
{
    public static int CountWithoutEnumerationIfPossible<T>(this IEnumerable<T> items)
    {
        if (!items.TryGetNonEnumeratedCount<T>(out var count))
        {
            count = items.Count();
        }

        return count;
    }
}