using UnityEngine;

namespace LudumDare34
{
  public abstract class BaseMovable : IMovable
  {
    public abstract float Gravity { get; }
    public abstract float MoveSpeed { get; }

    protected abstract IView View { get; }

    public virtual Vector3 Velocity { get; protected set; }
    public virtual float? MoveSpeedOverride { get; set; }

    public virtual Collider2D Collider => View.Collider;
    public virtual Vector3 Position => View.Transform.position;
    public virtual Vector3 CenterPoint => Collider.bounds.center;
    public virtual int FacingDirection => View.Transform.localScale.x.Sign();
    public virtual bool IsFalling => Velocity.y < 0f;
    public virtual bool IsGrounded => View.CharacterController.IsGrounded;
    public virtual bool WasGrounded => View.CharacterController.WasGroundedLastFrame;
    public virtual LayerMask CollisionLayers => View.CharacterController.PlatformMask;

    public virtual void Move(Vector3 moveVelocity)
    {
      View.CharacterController.Move(moveVelocity * Time.deltaTime);
      Velocity = View.CharacterController.Velocity;
    }

    public virtual void Flip() => View.Transform.Flip();

    public virtual bool Jump(float height)
    {
      if (height <= 0f || !IsGrounded)
        return false;

      Velocity = Velocity.SetY(Mathf.Sqrt(2f * height * -Gravity));

      return true;
    }

    public virtual void ApplyKnockback(Vector2 knockback, Vector2 direction)
    {
      if (knockback.IsZero())
        return;

      knockback.x += Mathf.Sqrt(Mathf.Abs(Mathf.Pow(knockback.x, 2) * -Gravity));

      if (IsGrounded)
        Velocity = Velocity.SetY(Mathf.Sqrt(Mathf.Abs(knockback.y * -Gravity)));

      knockback.Scale(direction);

      if (knockback.IsZero())
        return;

      Velocity += knockback.ToVector3();
      View.CharacterController.Move(Velocity * Time.deltaTime);
      Velocity = View.CharacterController.Velocity;
    }

    public virtual void Disable() { }
  }
}