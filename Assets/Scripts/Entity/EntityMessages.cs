using PachowStudios.Framework.Messaging;

namespace PachowStudios.BossWave.Entity
{
  public class EntityJumpedMessage : IMessage { }

  public class EntityHitMessage : IMessage
  {
    public IDamageSource Source { get; }

    public EntityHitMessage(IDamageSource source)
    {
      Source = source;
    }
  }
}
