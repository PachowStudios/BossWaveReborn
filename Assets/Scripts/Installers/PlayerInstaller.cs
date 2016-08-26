using PachowStudios.BossWave.Player;
using PachowStudios.Framework.Animation;
using PachowStudios.Framework.Movement;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Player Installer")]
  public class PlayerInstaller : MonoInstaller
  {
    [SerializeField] private PlayerFacade.Settings settings = null;

    private MovementController2D movementControllerComponent;
    private SpriteRenderer[] rendererComponents;
    private Animator animatorComponent;

    private MovementController2D MovementController => this.GetComponentIfNull(ref this.movementControllerComponent);
    private SpriteRenderer[] Renderers => this.GetComponentsInChildrenIfNull(ref this.rendererComponents);
    private Animator Animator => this.GetComponentIfNull(ref this.animatorComponent);

    public override void InstallBindings()
    {
      Container.BindInstance(MovementController).WhenInjectedInto<PlayerModel>();
      Container.BindInstance(Renderers).WhenInjectedInto<PlayerModel>();

      Container.BindInstance(Animator).WhenInjectedInto<IAnimationController>();
      Container.BindAllInterfaces<AnimationController>().To<AnimationController>().AsSingle();

      Container.Bind<PlayerInput>().AsSingle();
    }
  }
}
