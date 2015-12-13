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

    protected abstract IInputControl FightInput { get; }

    protected FiniteStateMachine<PlayerController> StateMachine { get; private set; }

    [PostInject]
    protected virtual void Initialize()
    {
      Aggregator.Subscribe(this);

      StateMachine = new FiniteStateMachine<PlayerController>(this)
        .AddState<IdleState>()
        .AddState<AttackingState>()
        .AddState<TakingDamageState>();
    }

    public virtual void Tick()
      => StateMachine.Tick();

    public void Handle(PlayerCollidedMessage message)
    {
      if (StateMachine.IsIn<AttackingState>())
        return;

      StateMachine.GoTo<TakingDamageState>();
    }
  }
}