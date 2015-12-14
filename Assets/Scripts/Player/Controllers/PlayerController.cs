using InControl;
using Zenject;

namespace LudumDare34
{
  public abstract partial class PlayerController : IPlayerController,
    IHandles<PlayerCollidedMessage>
  {
    [Inject] public PlayerMovement Movement { get; private set; }
    [Inject] public PlayerHealth Health { get; private set; }

    [InjectLocal] private IEventAggregator Aggregator { get; set; }

    public abstract IInputControl FightInput { get; }

    protected FiniteStateMachine<PlayerController> StateMachine { get; private set; }

    public IFiniteState CurrentState => StateMachine.CurrentState;

    [PostInject]
    protected virtual void Initialize()
    {
      Aggregator.Subscribe(this);

      StateMachine = new FiniteStateMachine<PlayerController>(this)
        .Add<IdleState>()
        .Add<JumpState>()
        .Add<AttackState>()
        .Add<TakeDamageState>();
    }

    public virtual void Tick()
      => StateMachine.Tick();

    public void Handle(PlayerCollidedMessage message)
    {
      if (message.OtherPlayer.CurrentState is JumpState)
        StateMachine.GoTo<TakeDamageState>();
    }
  }
}