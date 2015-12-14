using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public sealed class PlayerMovement : BaseMovable, ITickable
  {
    [Serializable, UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class Settings
    {
      public float Gravity = -35f;
      public float MoveSpeed = 5f;
      public float JumpHeight = 5f;
      public float GroundDamping = 10f;
      public float AirDamping = 5f;
      public float IdleMovementRange = 2f;
      public Vector2 ChangeDirectionTimeRange = new Vector2(0.5f, 2f);
      public Vector2 KnockbackOnDamage = new Vector2(3f, 2f);
    }

    [Inject] public Settings Config { get; private set; }

    [Inject] private PlayerView PlayerView { get; set; }

    public int HorizontalMovement { get; set; }

    public override float Gravity => Config.Gravity;
    public override float MoveSpeed => Config.MoveSpeed;

    protected override IView View => PlayerView;

    public void Tick()
    {
      ApplyMovement();
    }

    public void JumpTowardsEnemy()
      => JumpTowardsEnemy(Config.JumpHeight);

    public void JumpTowardsEnemy(float height)
    {
      if (HorizontalMovement != FacingDirection)
      {
        Velocity = Vector3.zero;
        HorizontalMovement = FacingDirection;
      }

      Jump(height);
    }

    public void ApplyDamageKnockback()
      => ApplyKnockback(Config.KnockbackOnDamage, Vector3.one.SetX(-FacingDirection));

    private void ApplyMovement()
    {
      var smoothedMovement = IsGrounded ? Config.GroundDamping : Config.AirDamping;

      Velocity = Velocity.SetX(
        Mathf.Lerp(
          Velocity.x,
          HorizontalMovement * MoveSpeed,
          smoothedMovement * Time.deltaTime));

      Velocity = Velocity.AddY(Gravity * Time.deltaTime);
      Move(Velocity);

      if (IsGrounded)
        Velocity = Velocity.SetY(0f);
    }
  }
}