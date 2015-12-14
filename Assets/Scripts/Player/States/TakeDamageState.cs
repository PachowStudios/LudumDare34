namespace LudumDare34
{
  public class TakeDamageState : FiniteState<PlayerController>
  {
    private PlayerMovement Movement => Context.Movement;

    public TakeDamageState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
      => Movement.ApplyDamageKnockback();

    public override void Reason()
    {
      if (Movement.IsGrounded
          && StateMachine.TimeInCurrentState >= 0.1f)
        StateMachine.GoTo<IdleState>();
    }

    public override void End()
      => Movement.HorizontalMovement = 0;
  }
}