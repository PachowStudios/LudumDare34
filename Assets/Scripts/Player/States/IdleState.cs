using InControl;
using UnityEngine;

namespace LudumDare34
{
  public class IdleState : FiniteState<PlayerController>
  {
    private readonly float startingX;

    private float changeDirectionTimer;

    private PlayerMovement Movement => Context.Movement;
    private IInputControl FightInput => Context.FightInput;
    private bool IsPastLeftBoundary => Movement.Position.x <= this.startingX - Movement.Config.IdleMovementRange;
    private bool IsPastRightBoundary => Movement.Position.x >= this.startingX + Movement.Config.IdleMovementRange;

    public IdleState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context)
    {
      this.startingX = Movement.Position.x;
    }

    public override void Begin()
    {
      if (Movement.HorizontalMovement == 0)
        Movement.HorizontalMovement = MathHelper.RandomSign();

      ResetTimer();
    }

    public override void Reason()
    {
      if (FightInput.WasPressed)
        StateMachine.GoTo<JumpState>();
    }

    public override void Tick()
    {
      if (IsPastLeftBoundary || IsPastRightBoundary)
      {
        Movement.HorizontalMovement = IsPastLeftBoundary ? 1 : -1;

        return;
      }

      this.changeDirectionTimer -= Time.deltaTime;

      if (this.changeDirectionTimer <= 0f)
      {
        Movement.HorizontalMovement *= -1;
        ResetTimer();
      }
    }

    private void ResetTimer()
      => this.changeDirectionTimer = Movement.Config.ChangeDirectionTimeRange.RandomRange();
  }
}