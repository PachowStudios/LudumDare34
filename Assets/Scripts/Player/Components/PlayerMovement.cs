using Zenject;

namespace LudumDare34
{
  public sealed class PlayerMovement : BaseMovable, ITickable
  {
    [Inject] private PlayerView PlayerView { get; set; }

    protected override IView View => PlayerView;

    public void Tick() { }
  }
}