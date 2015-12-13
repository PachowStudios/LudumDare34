using InControl;

namespace LudumDare34
{
  public class HumanPlayerController : PlayerController
  {
    protected override IInputControl FightInput => PlayerInput.Fight;

    private PlayerActions PlayerInput { get; set; }

    public override void Initialize()
    {
      PlayerInput = PlayerActions.CreateForPlayer(Registration.Id);
    }

    public override void Tick()
    {
      
    }
  }
}