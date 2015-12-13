using Zenject;

namespace LudumDare34
{
  public class PlayerController : IPlayerController
  {
    [Inject] public IMovable Movement { get; private set; }
    [Inject] public IHasHealth Health { get; private set; }
  }
}