using Zenject;

namespace LudumDare34
{
  public interface IPlayerController : ITickable
  {
    PlayerMovement Movement { get; }
    PlayerHealth Health { get; }
  }
}