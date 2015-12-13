using UnityEngine;

namespace LudumDare34
{
  public interface IView
  {
    Transform Transform { get; }
    Collider2D Collider { get; }
    CharacterController2D CharacterController { get; }
  }
}