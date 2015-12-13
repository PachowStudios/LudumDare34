namespace LudumDare34
{
  public interface IPlayer
  {
    IMovable Movement { get; }
    IHasHealth Health { get; }
  }
}