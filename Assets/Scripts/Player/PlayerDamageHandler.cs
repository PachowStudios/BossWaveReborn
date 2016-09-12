using PachowStudios.BossWave.Entity;
using PachowStudios.Framework.Assertions;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Primitives;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerDamageHandler : IHandle<EntityDamagedMessage>
  {
    private Settings Config { get; }
    private ExternalForces ExternalForces { get; }
    private PlayerModel Model { get; }

    public PlayerDamageHandler(
      Settings config,
      ExternalForces externalForces,
      PlayerModel model,
      IEventAggregator eventAggregator)
    {
      Config = config;
      ExternalForces = externalForces;
      Model = model;

      eventAggregator.Subscribe(this);
    }

    private void Knockback(Vector2 force, Vector2 source)
    {
      if (Model.IsDead || force.IsZero())
        return;

      force = force.Transform(x: x => (x.Square() * -ExternalForces.Gravity).Abs().SquareRoot());

      if (Model.IsGrounded)
        force = force.Transform(y: y => (y * -ExternalForces.Gravity).Abs().SquareRoot());

      // If the source is to the right of this, knockback to the left
      force.Scale(Model.Position.RelationTo(source));

      if (!force.IsZero())
        Model.Move(Model.Velocity + force);
    }

    public void Handle(EntityDamagedMessage message)
    {
      var source = message.Source;

      source.Damage.Should().BeGreaterThan(0, "because the player cannot take negative damage.");

      Model.Health -= source.Damage;
      Wait.ForSeconds(Config.KnockbackDelay, () => Knockback(source.Knockback, source.Position));
    }
  }
}
