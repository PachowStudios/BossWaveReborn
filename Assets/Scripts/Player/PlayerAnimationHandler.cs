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
    private IAnimationController AnimationController { get; }

    private Timer IdleActionTimer { get; }

    public PlayerAnimationHandler(
      Settings config,
      PlayerModel model,
      IAnimationController animationController,
      IEventAggregator eventAggregator)
    {
      Config = config;
      Model = model;
      AnimationController = animationController
        .Add("IsWalking", () => Model.IsWalking)
        .Add("IsRunning", () => Model.IsRunning)
        .Add("IsFalling", () => Model.IsFalling)
        .Add("IsGrounded", () => Model.IsGrounded);

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
