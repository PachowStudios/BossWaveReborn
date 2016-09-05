using PachowStudios.Framework.Messaging;

namespace PachowStudios.BossWave.Entity
{
  public class EntityJumpedMessage : IMessage { }

  public class EntityDamagedMessage : IMessage
  {
    public IDamageSource Source { get; }

    public EntityDamagedMessage(IDamageSource source)
    {
      Source = source;
    }
  }
}
