using InControl;

namespace LudumDare34
{
  public class PlayerActions : PlayerActionSet
  {
    public PlayerAction Fight { get; }

    private PlayerActions()
    {
      Fight = CreatePlayerAction("Fight!");
    }

    public static PlayerActions CreateForPlayer(PlayerId playerId)
    {
      var playerActions = new PlayerActions();

      switch (playerId)
      {
        case PlayerId.Player1:
          AssignBindingsForPlayer1(playerActions);
          break;
        case PlayerId.Player2:
          AssignBindingsForPlayer2(playerActions);
          break;
      }

      playerActions.ListenOptions.MaxAllowedBindings = 1;
      playerActions.ListenOptions.IncludeUnknownControllers = false;
      playerActions.ListenOptions.OnBindingFound = OnBindingFound;

      return playerActions;
    }

    private static void AssignBindingsForPlayer1(PlayerActions playerActions)
      => playerActions.Fight.AddDefaultBinding(Key.A);

    private static void AssignBindingsForPlayer2(PlayerActions playerActions)
      => playerActions.Fight.AddDefaultBinding(Key.L);

    private static bool OnBindingFound(PlayerAction action, BindingSource binding)
    {
      if (binding != new KeyBindingSource(Key.Escape))
        return true;

      action.StopListeningForBinding();

      return false;
    }
  }
}