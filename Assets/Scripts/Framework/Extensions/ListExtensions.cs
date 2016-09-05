using JetBrains.Annotations;

namespace System.Collections.Generic
{
  public static class ListExtensions
  {
    [Pure]
    public static bool IsFull<T>([NotNull] this List<T> list)
      => list.Count == list.Capacity;
  }
}