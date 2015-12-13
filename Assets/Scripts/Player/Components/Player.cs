using Zenject;

namespace LudumDare34
{
  public class Player
  {
    [Inject] private PlayerId Id { get; set; }
    [Inject] private IPlayerController Controller { get; set; }
  }
}