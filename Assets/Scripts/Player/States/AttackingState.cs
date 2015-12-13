namespace LudumDare34
{
  public class AttackingState : FiniteState<PlayerController>
  {
    public AttackingState(FiniteStateMachine<PlayerController> stateMachine, PlayerController context)
      : base(stateMachine, context) { }
  }
}