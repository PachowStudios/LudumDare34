namespace LudumDare34
{
  public class PlayerRegistration
  {
    public PlayerId Id { get; }
    public PlayerType Type { get; }

    public PlayerRegistration(PlayerId id, PlayerType type)
    {
      Id = id;
      Type = type;
    }
  }
}