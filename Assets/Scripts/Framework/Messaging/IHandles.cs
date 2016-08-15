using JetBrains.Annotations;

namespace PachowStudios.Framework.Messaging
{
  public interface IHandles { }

  public interface IHandles<in TMessage> : IHandles
    where TMessage : IMessage
  {
    void Handle([NotNull] TMessage message);
  }
}