using UnityEngine;
using Zenject;

namespace LudumDare34
{
  public sealed class PlayerHealth : BaseHasHealth, ITickable
  {
    [SerializeField] private int maxHealth = 100;

    [Inject] private PlayerView PlayerView { get; set; }

    protected override IView View => PlayerView;

    public override int MaxHealth => this.maxHealth;

    public override int Health { get; protected set; }

    public void Tick() { }

    public override void Damage(int damage, Vector2 knockback, Vector2 knockbackDirection) { }

    public override void Kill() { }
  }
}