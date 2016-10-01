using PachowStudios.BossWave.Projectiles;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Projectile Installer")]
  public partial class ProjectileInstaller : MonoInstaller
  {
    [SerializeField] private Settings config = null;

    private Vector2 Direction { get; set; }

    [Inject]
    public void Construct(Vector2 direction)
      => Direction = direction;

    public override void InstallBindings()
    {
      Container.Bind<ProjectileModel>().AsSingle();
      Container.BindInstance(this.config.Components).WhenInjectedInto<ProjectileModel>();

      Container.BindAllInterfaces<ProjectileMoveHandler>().To<ProjectileMoveHandler>();
      Container.BindInstance(this.config.MoveHandler).WhenInjectedInto<ProjectileMoveHandler>();
    }
  }
}
