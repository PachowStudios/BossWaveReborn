using PachowStudios.BossWave.Player;
using PachowStudios.Framework.Animation;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Movement;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Player Installer")]
  public class PlayerInstaller : MonoInstaller
  {
    [SerializeField] private PlayerFacade.Settings config = null;

    private MovementController2D movementControllerComponent;
    private SpriteRenderer[] rendererComponents;
    private Animator animatorComponent;

    private IEventAggregator EventAggregator { get; set; }

    private MovementController2D MovementController => this.GetComponentIfNull(ref this.movementControllerComponent);
    private SpriteRenderer[] Renderers => this.GetComponentsInChildrenIfNull(ref this.rendererComponents);
    private Animator Animator => this.GetComponentIfNull(ref this.animatorComponent);

    [Inject]
    public void Construct(IEventAggregator eventAggregator)
      => EventAggregator = eventAggregator;

    public override void InstallBindings()
    {
      Container.Bind<PlayerModel>().AsSingle();
      Container.BindInstance(MovementController).WhenInjectedInto<PlayerModel>();
      Container.BindInstance(Renderers).WhenInjectedInto<PlayerModel>();

      Container.Bind<PlayerInput>().AsSingle();

      Container.BindAllInterfaces<AnimationController>().To<AnimationController>().AsSingle();
      Container.BindInstance(Animator).WhenInjectedInto<IAnimationController>();

      Container.BindAllInterfaces<PlayerAnimationHandler>().To<PlayerAnimationHandler>().AsSingle();
      Container.BindInstance(this.config.AnimationHandler).WhenInjectedInto<PlayerAnimationHandler>();

      Container.BindAllInterfaces<PlayerMoveHandler>().To<PlayerMoveHandler>().AsSingle();
      Container.BindInstance(this.config.MoveHandler).WhenInjectedInto<PlayerMoveHandler>();

      Container.BindAllInterfaces<PlayerHitHandler>().To<PlayerHitHandler>().AsSingle();
      Container.BindInstance(this.config.HitHandler).WhenInjectedInto<PlayerHitHandler>();

      Container.BindInstance(this.config.ExternalForces);

      Container.BindAllInterfaces<EventAggregator>().FromMethod(c => EventAggregator.CreateChildContext()).AsSingle();
    }
  }
}
