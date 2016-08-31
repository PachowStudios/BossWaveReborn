using System;
using Random = UnityEngine.Random;

namespace PachowStudios.Framework.Primitives
{
  public class Timer
  {
    public float RemainingTime { get; private set; }
    public float Interval { get; private set; }

    private float MinInterval { get; }
    private float MaxInterval { get; }
    private Action Callback { get; }

    public Timer(float interval, Action callback)
      : this(interval, interval, callback) { }

    public Timer(float minInterval, float maxInterval, Action callback)
    {
      MinInterval = minInterval;
      MaxInterval = maxInterval;
      Callback = callback;

      Reset();
    }

    public void Tick(float deltaTime)
    {
      RemainingTime -= deltaTime;

      if (RemainingTime <= 0f)
      {
        Callback();
        Reset();
      }
    }

    public void Reset()
      => RemainingTime = Interval = Random.Range(MinInterval, MaxInterval);
  }
}
