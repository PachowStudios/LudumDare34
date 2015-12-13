using UnityEngine;

namespace LudumDare34
{
  public class PlayerHealth : BaseHasHealth
  {
    [SerializeField] private int maxHealth = 100;

    public override int MaxHealth => this.maxHealth;
    public override int Health { get; protected set; }

    public override void Damage(int damage, Vector2 knockback, Vector2 knockbackDirection) { }

    public override void Kill() { }
  }
}