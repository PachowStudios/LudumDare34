using InControl;

namespace LudumDare34
{
  public class AiPlayerController : PlayerController
  {
    protected override IInputControl FightInput => AiInput;

    private AiInputControl AiInput { get; set; }

    public override void Initialize()
    {
      AiInput = new AiInputControl();
    }

    public override void Tick()
    {
      AiInput.Tick();
    }
  }
}