using PachowStudios.BossWave.Entity;
using PachowStudios.Framework.Messaging;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerMoveHandler : ILateTickable
  {
    private Settings Config { get; }
    private PlayerExternalForceSettings ExternalForces { get; }
    private PlayerModel Model { get; }
    private PlayerInput Input { get; }
    private IEventAggregator EventAggregator { get; }

    private Vector2 Velocity
    {
      get { return Model.Velocity; }
      set { Model.Velocity = value; }
    }

    private bool CanJump => Input.Jump.WasPressed && Model.IsGrounded;
    private float MoveSpeed => Model.IsRunning ? Config.RunSpeed : Config.WalkSpeed;
    private float MovementDamping => Model.IsGrounded ? ExternalForces.GroundDamping : ExternalForces.AirDamping;

    public PlayerMoveHandler(
      Settings config,
      PlayerExternalForceSettings externalForces,
      PlayerModel model,
      PlayerInput input,
      IEventAggregator eventAggregator)
    {
      Config = config;
      ExternalForces = externalForces;
      Model = model;
      Input = input;
      EventAggregator = eventAggregator;
    }

    public void LateTick()
    {
      if (CanJump)
        Jump();

      Model.Move(
        Velocity
          .Transform(CalculateHorizontalVelocity)
          .Add(y: ExternalForces.Gravity * Time.deltaTime));

      if (Model.IsGrounded)
        OnPlayerGrounded();
    }

    private void Jump()
    {
      Velocity = Velocity.Set(y: CalculateJumpVelocity());
      EventAggregator.PublishLocally(new EntityJumpedMessage());
    }

    private float CalculateJumpVelocity()
      => Mathf.Sqrt(2f * Config.JumpHeight * -ExternalForces.Gravity);

    private float CalculateHorizontalVelocity(float x)
      => x.LerpTo(Input.Move * MoveSpeed, MovementDamping * Time.deltaTime);

    private void OnPlayerGrounded()
    {
      Velocity = Velocity.Set(y: 0f);
      Model.LastGroundedPosition = Model.Position;
    }
  }
}
