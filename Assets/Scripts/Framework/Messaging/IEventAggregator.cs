﻿using JetBrains.Annotations;

namespace PachowStudios.Framework.Messaging
{
  public interface IEventAggregator
  {
    void Subscribe<THandler>([NotNull] THandler subscriber)
      where THandler : class, IHandles;

    void Unsubscribe<THandler>([NotNull] THandler subscriber)
      where THandler : class, IHandles;

    void Publish<TMessage>([NotNull] TMessage message)
      where TMessage : IMessage;

    [Pure]
    bool HandlerExistsFor<TMessage>()
      where TMessage : IMessage;
  }
}