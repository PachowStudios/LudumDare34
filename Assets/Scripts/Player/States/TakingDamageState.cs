namespace LudumDare34
{
  public class TakingDamageState : FiniteState<PlayerController>
  {
    private PlayerMovement Movement => Context.Movement;

    public TakingDamageState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
      => Movement.ApplyDamageKnockback();

    public override void Reason()
    {
      if (StateMachine.TimeInCurrentState >= 0.25f
          && Movement.IsGrounded)
        StateMachine.GoTo<IdleState>();
    }

    public override void End()
      => Movement.HorizontalMovement = 0;
  }
}