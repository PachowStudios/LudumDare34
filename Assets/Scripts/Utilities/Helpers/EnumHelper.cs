using System;
using System.Collections.Generic;

namespace LudumDare34
{
  public static class EnumHelper
  {
    public static IEnumerable<T> GetValues<T>()
      => (T[])Enum.GetValues(typeof(T));
  }
}