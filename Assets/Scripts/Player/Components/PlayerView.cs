using UnityEngine;
using Zenject;

namespace LudumDare34
{
  [AddComponentMenu("Ludum Dare 34/Player/View")]
  public partial class PlayerView : BaseView
  {
    [Inject] public PlayerFacade Player { get; private set; }

    // Cause Tumblr triggers people
    [InjectLocal] private IEventAggregator Tumblr { get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag != Tags.Player)
        return;

      var otherPlayer = other.GetComponent<PlayerView>();

      if (otherPlayer != null && Player.Id != otherPlayer.Player.Id)
        Tumblr.Publish(new PlayerCollidedMessage(otherPlayer.Player));
    }
  }
}