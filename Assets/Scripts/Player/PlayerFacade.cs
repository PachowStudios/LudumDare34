using Zenject;

namespace LudumDare34
{
  public partial class PlayerFacade : Facade
  {
    [Inject] private PlayerRegistration Registration { get; set; }
    [Inject] private IPlayerController Controller { get; set; }

    public PlayerId Id => Registration.Id;
    public IMovable Movement => Controller.Movement;
    public IHasHealth Health => Controller.Health;
    public IFiniteState CurrentState => Controller.CurrentState;
  }
}