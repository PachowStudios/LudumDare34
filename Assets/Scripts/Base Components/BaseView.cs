using UnityEngine;

namespace LudumDare34
{
  public abstract class BaseView : MonoBehaviour, IView
  {
    private Transform transformComponent;
    private Collider2D colliderComponent;
    private CharacterController2D characterControllerComponent;

    public Transform Transform => this.GetComponentIfNull(ref this.transformComponent);
    public Collider2D Collider => this.GetComponentIfNull(ref this.colliderComponent);
    public CharacterController2D CharacterController => this.GetComponentIfNull(ref this.characterControllerComponent);
  }
}