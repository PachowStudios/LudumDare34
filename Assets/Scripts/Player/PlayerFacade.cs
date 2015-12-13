using Zenject;

namespace LudumDare34
{
  public partial class PlayerFacade : Facade
  {
    [Inject] private IPlayerController Controller { get; set; }
  }
}