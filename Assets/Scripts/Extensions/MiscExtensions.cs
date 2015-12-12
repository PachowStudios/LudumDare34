using System;

namespace Zenject
{
  public static class MiscExtensions
  {
    public static void BindLifetimeSingleton<T>(this DiContainer container)
    where T : IInitializable, IDisposable
    {
      container.Bind<IInitializable>().ToSingle<T>();
      container.Bind<IDisposable>().ToSingle<T>();
    }
  }
}

namespace System
{
  public static class MiscExtensions
  {
    public static bool IsAssignableFrom<T>(this Type parent)
      => parent.IsAssignableFrom(typeof(T));
  }
}