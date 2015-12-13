using Zenject;

namespace LudumDare34
{
  public interface IPlayerController : ITickable
  {
    PlayerRegistration Registration { get; }
    IMovable Movement { get; }
    IHasHealth Health { get; }
  }
}