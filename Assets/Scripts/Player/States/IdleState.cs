using UnityEngine;

namespace LudumDare34.States
{
  public class IdleState : FiniteState<PlayerController>
  {
    private float changeDirectionTimer;

    public IdleState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
    {
      if (Context.Movement.HorizontalMovement == 0)
        Context.Movement.HorizontalMovement = MathHelper.RandomSign();

      ResetTimer();
    }

    public override void Tick()
    {
      this.changeDirectionTimer -= Time.deltaTime;

      if (this.changeDirectionTimer <= 0f)
      {
        Context.Movement.HorizontalMovement *= -1;
        ResetTimer();
      }
    }

    private void ResetTimer()
      => this.changeDirectionTimer =
        Context.Movement.Config.ChangeDirectionTimeRange.RandomRange();
  }
}