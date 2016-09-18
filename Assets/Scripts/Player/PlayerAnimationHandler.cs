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

    private bool IsIdle => !IsWalking && IsGrounded && !IsShooting;
    private bool IsWalking => Input.IsWalking;
    private bool IsRunning => Input.IsRunning;
    private bool IsFalling => Model.IsFalling;
    private bool IsGrounded => Model.IsGrounded;
    private bool IsShooting => Model.CurrentGun.IsShooting;
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
        .Add("IsIdle", () => IsIdle)
        .Add("IsWalking", () => IsWalking)
        .Add("IsRunning", () => IsRunning)
        .Add("IsFalling", () => IsFalling)
        .Add("IsGrounded", () => IsGrounded)
        .Add("IsShooting", () => IsShooting)
        .Add("AimX", () => NormalizedAim.x)
        .Add("AimY", () => NormalizedAim.y);

      IdleActionTimer = new Timer(Config.IdleActionInterval.x, Config.IdleActionInterval.y, DoIdleAction);

      eventAggregator.Subscribe(this);
    }

    public void Tick()
    {
      if (IsIdle)
        IdleActionTimer.Tick(Time.deltaTime);
    }

    private void DoIdleAction()
      => AnimationController.Trigger("DoIdleAction");

    public void Handle(EntityJumpedMessage message)
      => AnimationController.Trigger("DoJump");
  }
}
