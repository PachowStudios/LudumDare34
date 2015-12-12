using UnityEngine;

namespace Character
{
  public interface IMovable
  {
    float? MoveSpeedOverride { get; set; }

    float Gravity { get; }
    float MoveSpeed { get; }
    Collider2D Collider { get; }
    Vector3 Position { get; }
    Vector3 CenterPoint { get; }
    Vector3 Velocity { get; }
    Vector2 MovementDirection { get; }
    int FacingDirection { get; }
    bool IsFalling { get; }
    bool IsGrounded { get; }
    bool WasGrounded { get; }
    LayerMask CollisionLayers { get; }

    void Move(Vector3 moveVelocity);
    void Flip();
    bool Jump(float jumpHeight);
    void ApplyKnockback(Vector2 knockback, Vector2 direction);
    void Disable();
  }
}