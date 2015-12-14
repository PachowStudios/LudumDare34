using InControl;

namespace LudumDare34
{
  public class AttackState : FiniteState<PlayerController>
  {
    private PlayerMovement Movement => Context.Movement;
    private IInputControl FightInput => Context.FightInput;

    public AttackState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }

    public override void Begin()
    {
      
    }
  }
}