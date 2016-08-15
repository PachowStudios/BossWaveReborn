﻿using JetBrains.Annotations;

namespace PachowStudios.Framework.Messaging
{
  public partial class EventAggregator
  {
    private interface IWeakEventHandler
    {
      bool IsAlive { get; }

      bool Handle<TMessage>([NotNull] TMessage message)
        where TMessage : IMessage;

      [Pure]
      bool Handles<TMessage>()
        where TMessage : IMessage;

      [Pure]
      bool RefersTo<T>(T instance)
        where T : class, IHandles;
    }
  }
}