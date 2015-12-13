using InControl;

namespace LudumDare34
{
  public sealed class AiPlayerController : PlayerController
  {
    private AiInputControl AiInput { get; set; }

    protected override IInputControl FightInput => AiInput;

    public override void Initialize()
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