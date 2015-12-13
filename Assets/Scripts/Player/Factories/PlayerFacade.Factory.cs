using Zenject;

namespace LudumDare34
{
  public partial class PlayerFacade
  {
    public class Factory : FacadeFactory<PlayerRegistration, PlayerFacade>
    {
      public PlayerFacade Create(PlayerId id, PlayerType type)
        => Create(new PlayerRegistration(id, type));
    }
  }
}