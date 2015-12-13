using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public class IdleState : FiniteState<PlayerController>
  {
    private float changeDirectionTimer;

    [Inject] private PlayerMovement Movement => Context.Movement;

    public IdleState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
    {
      if (Movement.HorizontalMovement == 0)
        Movement.HorizontalMovement = MathHelper.RandomSign();

      ResetTimer();
    }

    public override void Tick()
    {
      this.changeDirectionTimer -= Time.deltaTime;

      if (this.changeDirectionTimer <= 0f)
      {
        Movement.HorizontalMovement *= -1;
        ResetTimer();
      }
    }

    private void ResetTimer()
      => this.changeDirectionTimer =
        Movement.Config.ChangeDirectionTimeRange.RandomRange();
  }
}