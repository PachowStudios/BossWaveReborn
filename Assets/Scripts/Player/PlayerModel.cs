using PachowStudios.Framework.Assertions;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public class PlayerModel
  {
    private int health;

    public Vector3 Position
    {
      get { return MovementController.Position; }
      set { MovementController.Position = value; }
    }

    public int Health
    {
      get { return this.health; }
      private set
      {
        this.health = value.Clamp(0, Health);
        RaiseHealthChanged();
      }
    }

    public bool IsDead { get; set; }
    public Vector3 LastGroundedPosition { get; set; }
    public Vector2 Velocity { get; set; }
    public bool IsRunning { get; set; }

    public Vector3 CenterPoint => MovementController.CenterPoint;
    public bool IsWalking => Input.Move;
    public bool IsFalling => Velocity.y < 0f;
    public bool IsGrounded => MovementController.IsGrounded;
    public bool IsIdle => Velocity.IsZero();

    public SpriteRenderer[] Renderers { get; }

    private PlayerInput Input { get; }
    private MovementController2D MovementController { get; }
    private IEventAggregator EventAggregator { get; }

    public PlayerModel(
      PlayerInput input,
      MovementController2D movementController,
      SpriteRenderer[] renderers,
      IEventAggregator eventAggregator)
    {
      Input = input;
      MovementController = movementController;
      Renderers = renderers;
      EventAggregator = eventAggregator;
    }

    public void Move(Vector3 velocity)
      => Velocity = MovementController.Move(velocity);

    public void TakeDamage(int damage)
    {
      damage.Should().BeGreaterThan(0, "because the player cannot take negative damage.");

      Health -= damage;
    }

    private void RaiseHealthChanged()
      => EventAggregator.Publish(new PlayerHealthChangedMessage());
  }
}