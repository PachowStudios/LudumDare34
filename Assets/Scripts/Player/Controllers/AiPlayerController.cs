using InControl;

namespace LudumDare34
{
  public sealed class AiPlayerController : PlayerController
  {
    private AiInputControl AiInput { get; set; }

    public override IInputControl FightInput => AiInput;

    protected override void Initialize()
    {
      base.Initialize();

      AiInput = new AiInputControl();
    }

    public override void Tick()
    {
      base.Tick();

      AiInput.Tick();
    }
  }
}