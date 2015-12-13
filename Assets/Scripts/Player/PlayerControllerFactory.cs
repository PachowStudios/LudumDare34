using Zenject;

namespace LudumDare34
{
  public class PlayerControllerFactory : IFactory<PlayerType, IMovable, IHasHealth, PlayerController>
  {
    [Inject] private IInstantiator Instantiator { get; }

    public PlayerController Create(PlayerType type, IMovable movement, IHasHealth health)
    {
      return Instantiator.Instantiate<PlayerController>(movement, health);
    }
  }
}