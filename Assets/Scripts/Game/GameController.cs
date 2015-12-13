using Zenject;

namespace LudumDare34
{
  public class GameController : IInitializable, ITickable
  {
    [Inject] private PlayerFacade.Factory PlayerFactory { get; set; }

    private PlayerFacade player1;
    private PlayerFacade player2;

    public void Initialize()
    {
      this.player1 = PlayerFactory.Create(PlayerId.Player1, PlayerType.Human);
      this.player2 = PlayerFactory.Create(PlayerId.Player2, PlayerType.Ai);
    }

    public void Tick()
    {
      this.player1.Tick();
      this.player2.Tick();
    }
  }
}