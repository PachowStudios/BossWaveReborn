using PachowStudios.BossWave.Entity;
using PachowStudios.Framework.Animation;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Primitives;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerAnimationHandler : ITickable, IHandle<EntityJumpedMessage>
  {
    private Settings Config { get; }
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }
    private IAnimationController AnimationController { get; }

    private Timer IdleActionTimer { get; }

    private Vector2 NormalizedAim => Model.CurrentGun.AimDirection.normalized;

    public PlayerAnimationHandler(
      Settings config,
      PlayerModel model,
      PlayerInput input,
      IAnimationController animationController,
      IEventAggregator eventAggregator)
    {
      Config = config;
      Model = model;
      Input = input;
      AnimationController = animationController
        .Add("IsWalking", () => Input.IsWalking)
        .Add("IsRunning", () => Input.IsRunning)
        .Add("IsFalling", () => Model.IsFalling)
        .Add("IsGrounded", () => Model.IsGrounded)
        .Add("IsShooting", () => Model.CurrentGun.IsShooting)
        .Add("AimX", () => NormalizedAim.x)
        .Add("AimY", () => NormalizedAim.y);

      IdleActionTimer = new Timer(Config.IdleActionInterval.x, Config.IdleActionInterval.y, DoIdleAction);

      eventAggregator.Subscribe(this);
    }

    public void Tick()
    {
      if (Model.IsIdle)
        IdleActionTimer.Tick(Time.deltaTime);
    }

    private void DoIdleAction()
      => AnimationController.Trigger("DoIdleAction");

    public void Handle(EntityJumpedMessage message)
      => AnimationController.Trigger("DoJump");
  }
}
