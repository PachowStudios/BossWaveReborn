using PachowStudios.BossWave.Projectiles;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Projectile Installer")]
  public partial class ProjectileInstaller : MonoInstaller
  {
    [SerializeField] private Settings config = null;

    public override void InstallBindings()
    {
      Container.Bind<ProjectileModel>().AsSingle();
    }
  }
}
