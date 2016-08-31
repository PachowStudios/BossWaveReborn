using PachowStudios.BossWave.Entity;
using PachowStudios.Framework.Messaging;
using PachowStudios.Framework.Primitives;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerHitHandler : IHandle<EntityHitMessage>
  {
    private Settings Config { get; }
    private PlayerExternalForceSettings ExternalForces { get; }
    private PlayerModel Model { get; }

    public PlayerHitHandler(
      Settings config,
      PlayerExternalForceSettings externalForces,
      PlayerModel model,
      IEventAggregator eventAggregator)
    {
      Config = config;
      ExternalForces = externalForces;
      Model = model;

      eventAggregator.Subscribe(this);
    }

    private void Knockback(Vector2 force, Vector3 source)
    {
      if (Model.IsDead || force.IsZero())
        return;

      force = force.Transform(x => (x.Square() * -ExternalForces.Gravity).Abs().SquareRoot());

      if (Model.IsGrounded)
        force = force.Transform(y: y => (y * -ExternalForces.Gravity).Abs().SquareRoot());

      // If the source is to the right of this, knockback to the left
      force.Scale(Model.Position.RelationTo(source));

      if (!force.IsZero())
        Model.Move(Model.Velocity + force);
    }

    public void Handle(EntityHitMessage message)
    {
      var source = message.Source;

      Model.TakeDamage(source.Damage);
      Wait.ForSeconds(Config.KnockbackDelay, () => Knockback(source.Knockback, source.Position));
    }
  }
}
