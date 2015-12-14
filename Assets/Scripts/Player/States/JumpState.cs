using InControl;

namespace LudumDare34
{
  public class JumpState : FiniteState<PlayerController>
  {
    private PlayerMovement Movement => Context.Movement;
    private IInputControl FightInput => Context.FightInput;

    public JumpState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
      => Movement.JumpTowardsEnemy();

    public override void Reason()
    {
      if (FightInput.WasPressed)
      {
        if (Movement.IsFalling)
          StateMachine.GoTo<AttackState>();
        else
          StateMachine.GoTo<AttackState>();
      }

      if (Movement.IsGrounded
          && StateMachine.TimeInCurrentState >= 0.1f)
        StateMachine.GoTo<IdleState>();
    }
  }
}