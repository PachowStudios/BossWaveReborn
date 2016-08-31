using UnityEngine;

namespace PachowStudios.BossWave.Entity
{
  public interface IDamageSource
  {
    int Damage { get; }
    Vector2 Knockback { get; }
    Vector2 Position { get; }
  }
}
