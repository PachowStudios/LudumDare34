using InControl;
using UnityEngine;

namespace LudumDare34
{
  public sealed class HumanPlayerController : PlayerController
  {
    private PlayerActions PlayerInput { get; set; }

    protected override IInputControl FightInput => PlayerInput.Fight;

    public override void Initialize()
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