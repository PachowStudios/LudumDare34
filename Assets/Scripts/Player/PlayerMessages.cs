namespace LudumDare34
{
  public class PlayerCollidedMessage : IMessage
  {
    public PlayerFacade OtherPlayer { get; }

    public PlayerCollidedMessage(PlayerFacade otherPlayer)
    {
      OtherPlayer = otherPlayer;
    }
  }
}