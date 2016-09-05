using UnityEngine;

namespace PachowStudios.BossWave.Entity
{
  public interface IDamageSource
  {
    DamageSourceType Type { get; }
    int Damage { get; }
    Vector2 Knockback { get; }
    Vector2 Position { get; }
  }
}
