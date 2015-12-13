using Zenject;

namespace LudumDare34
{
  public partial class PlayerFacade
  {
    public class Factory : FacadeFactory<PlayerRegistration, PlayerFacade> { }
  }
}