using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Projectiles
{
  [AddComponentMenu("Boss Wave/Projectiles/Projectile Facade")]
  public class ProjectileFacade : MonoBehaviour
  {
    private ProjectileModel Model { get; set; }

    [Inject]
    public void Construct(ProjectileModel model)
      => Model = model;
  }
}
