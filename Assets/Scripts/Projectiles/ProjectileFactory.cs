using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Projectiles
{
  public class ProjectileFactory : Factory<Vector2, ProjectileType, ProjectileFacade> { }
}
