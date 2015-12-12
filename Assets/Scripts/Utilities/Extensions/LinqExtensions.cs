using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using URandom = UnityEngine.Random;

// Needs to be in a sub-namespace so we don't conflict
// with plugins that have the same extensions
namespace System.Linq.Extensions
{
  public static class LinqExtensions
  {
    public static bool IsEmpty<T>(this IEnumerable<T> source)
      => source.Any();

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
      => source == null || source.IsEmpty();

    public static bool None<T>(this IEnumerable<T> source, Func<T, bool> condition)
      => !source.Any(condition);

    public static bool HasAtLeast<T>(this IEnumerable<T> source, int amount)
      => source.Take(amount).Count() == amount;

    public static bool HasMoreThan<T>(this IEnumerable<T> source, int amount)
      => source.HasAtLeast(amount + 1);

    public static bool HasAtMost<T>(this IEnumerable<T> souce, int amount)
      => souce.Take(amount + 1).Count() <= amount;

    public static bool HasLessThan<T>(this IEnumerable<T> source, int amount)
      => source.HasAtMost(amount - 1);

    public static bool HasSingle<T>(this IEnumerable<T> source)
      => source.HasAtMost(1);

    public static bool HasMultiple<T>(this IEnumerable<T> source)
      => source.HasAtLeast(2);

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
      foreach (var item in source)
        action?.Invoke(item);

      return source;
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action action)
    {
      // ReSharper disable once UnusedVariable
      foreach (var item in source)
        action?.Invoke();

      return source;
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
      => source.OrderBy(x => Guid.NewGuid());

    public static T GetRandom<T>(this IList<T> list)
      => list[URandom.Range(0, list.Count)];
  }
}