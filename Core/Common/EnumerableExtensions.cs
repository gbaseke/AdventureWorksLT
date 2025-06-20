using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether the IEnumerable is empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IEnumerable.</typeparam>
    /// <param name="source">The IEnumerable to check.</param>
    /// <returns>True if the IEnumerable is empty; otherwise, false.</returns>
    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
        return source == null || !source.Any();
    }
}