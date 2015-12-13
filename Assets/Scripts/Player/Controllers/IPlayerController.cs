using Zenject;

namespace LudumDare34
{
  public interface IPlayerController : ITickable
  {
    PlayerRegistration Registration { get; }
    PlayerMovement Movement { get; }
    PlayerHealth Health { get; }
  }
}