using System.Collections.Generic;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public class PlayerModel
  {
    private int health;

    public int Health
    {
      get { return this.health; }
      set
      {
        this.health = value.Clamp(0, MaxHealth);
        RaiseHealthChanged();
      }
    }

    public int MaxHealth { get; set; }
    public bool IsDead { get; set; }
    public Vector2 LastGroundedPosition { get; set; }
    public Vector2 Velocity { get; set; }
    public GunFacade CurrentGun { get; set; }

    public List<GunFacade> Guns { get; } = new List<GunFacade>();

    public Transform GunPoint => Components.GunPoint;
    public Vector2 Position => Transform.position;
    public Vector2 CenterPoint => MovementController.CenterPoint;
    public Vector2 LookDirection => Transform.localScale.Set(y: 0f);
    public bool IsLookingRight => LookDirection.x > 0f;
    public bool IsFalling => !IsGrounded && Velocity.y < 0f;
    public bool IsGrounded => MovementController.IsGrounded;

    private PlayerComponents Components { get; }
    private IEventAggregator EventAggregator { get; }

    private Transform Transform => Components.Body;
    private MovementController2D MovementController => Components.MovementController;

    public PlayerModel(PlayerComponents components, IEventAggregator eventAggregator)
    {
      Components = components;
      EventAggregator = eventAggregator;
    }

    public void Move(Vector3 velocity)
      => Velocity = MovementController.Move(velocity);

    public void Flip()
      => Transform.Flip();

    private void RaiseHealthChanged()
      => EventAggregator.Publish(new PlayerHealthChangedMessage());
  }
}