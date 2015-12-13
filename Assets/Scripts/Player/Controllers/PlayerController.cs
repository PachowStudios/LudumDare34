using InControl;
using LudumDare34.States;
using Zenject;

namespace LudumDare34
{
  public abstract partial class PlayerController : IPlayerController
  {
    [Inject] public PlayerRegistration Registration { get; private set; }
    [Inject] public PlayerMovement Movement { get; private set; }
    [Inject] public PlayerHealth Health { get; private set; }

    protected abstract IInputControl FightInput { get; }

    protected FiniteStateMachine<PlayerController> StateMachine { get; private set; }

    [PostInject]
    public virtual void Initialize()
      => StateMachine = new FiniteStateMachine<PlayerController>(this)
        .AddState<IdleState>();

    public virtual void Tick()
      => StateMachine.Tick();
  }
}