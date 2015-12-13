using InControl;
using Zenject;

namespace LudumDare34
{
  public abstract partial class PlayerController : IPlayerController
  {
    [Inject] public PlayerRegistration Registration { get; private set; }
    [Inject] public IMovable Movement { get; private set; }
    [Inject] public IHasHealth Health { get; private set; }

    protected abstract IInputControl FightInput { get; }

    public abstract void Initialize();

    public abstract void Tick();
  }
}