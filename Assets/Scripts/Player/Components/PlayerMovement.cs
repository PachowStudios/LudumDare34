using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public sealed class PlayerMovement : BaseMovable, ITickable
  {
    [Serializable]
    public class Settings
    {
      [UsedImplicitly] public float Gravity = -35f;
      [UsedImplicitly] public float MoveSpeed = 5f;
      [UsedImplicitly] public float IdleMovementRange = 4f;
      [UsedImplicitly] public Vector2 ChangeDirectionTimeRange = new Vector2(0.5f, 2f);
      [UsedImplicitly] public float JumpHeight = 5f;
      [UsedImplicitly] public float GroundDamping = 10f;
      [UsedImplicitly] public float AirDamping = 5f;
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