using InControl;
using Zenject;

namespace LudumDare34
{
  public sealed class HumanPlayerController : PlayerController
  {
    [Inject] private PlayerRegistration Registration { get; set; }

    private PlayerActions PlayerInput { get; set; }

    public override IInputControl FightInput => PlayerInput.Fight;

    protected override void Initialize()
    {
      base.Initialize();

      PlayerInput = PlayerActions.CreateForPlayer(Registration.Id);
    }

    public override void Tick()
    {
      base.Tick();
    }
  }
}