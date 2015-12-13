using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public class Player : MonoBehaviour, IPlayer
  {
    [Inject] private PlayerId Id { get; set; }
    [Inject] private PlayerController Controller { get; set; }

    public IMovable Movement => Controller.Movement;
    public IHasHealth Health => Controller.Health;
  }
}