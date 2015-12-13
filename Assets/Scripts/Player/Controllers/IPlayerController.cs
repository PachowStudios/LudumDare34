using Zenject;

namespace LudumDare34
{
  public interface IPlayerController : IInitializable, ITickable
  {
    PlayerRegistration Registration { get; }
    IMovable Movement { get; }
    IHasHealth Health { get; }
  }
}