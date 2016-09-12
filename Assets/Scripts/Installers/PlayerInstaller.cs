using PachowStudios.BossWave.Player;
using PachowStudios.Framework.Animation;
using PachowStudios.Framework.Messaging;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Player Installer")]
  public partial class PlayerInstaller : MonoInstaller
  {
    [SerializeField] private Settings config = null;

    private IEventAggregator EventAggregator { get; set; }


    [Inject]
    public void Construct(IEventAggregator eventAggregator)
      => EventAggregator = eventAggregator;

    public override void InstallBindings()
    {
      Container.Bind<PlayerModel>().AsSingle();
      Container.BindInstance(this.config.Components).WhenInjectedInto<PlayerModel>();

      Container.Bind<PlayerInput>().AsSingle();

      Container.BindAllInterfaces<AnimationController>().To<AnimationController>().AsSingle();
      Container.BindInstance(this.config.Components.Animator).WhenInjectedInto<IAnimationController>();

      Container.BindAllInterfaces<PlayerAnimationHandler>().To<PlayerAnimationHandler>().AsSingle();
      Container.BindInstance(this.config.AnimationHandler).WhenInjectedInto<PlayerAnimationHandler>();

      Container.BindAllInterfaces<PlayerMoveHandler>().To<PlayerMoveHandler>().AsSingle();
      Container.BindInstance(this.config.MoveHandler).WhenInjectedInto<PlayerMoveHandler>();

      Container.BindAllInterfaces<PlayerDirectionHandler>().To<PlayerDirectionHandler>().AsSingle();

      Container.BindAllInterfaces<PlayerDamageHandler>().To<PlayerDamageHandler>().AsSingle();
      Container.BindInstance(this.config.DamageHandler).WhenInjectedInto<PlayerDamageHandler>();

      Container.BindAllInterfaces<PlayerShootHandler>().To<PlayerShootHandler>().AsSingle();
      Container.BindInstance(this.config.ShootHandler).WhenInjectedInto<PlayerShootHandler>();

      Container.BindAllInterfaces<PlayerGunSelector>().To<PlayerGunSelector>().AsSingle();
      Container.BindInstance(this.config.GunSelector).WhenInjectedInto<PlayerGunSelector>();

      Container.BindInstance(this.config.ExternalForces);

      Container.BindAllInterfaces<EventAggregator>().FromMethod(c => EventAggregator.CreateChildContext()).AsSingle();
    }
  }
}
