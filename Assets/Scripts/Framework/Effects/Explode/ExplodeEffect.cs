using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace PachowStudios.Framework.Effects
{
  public class ExplodeEffect
  {
    private ExplodeEffectSettings Config { get; }
    private IInstantiator Instantiator { get; }

    public ExplodeEffect(ExplodeEffectSettings config, IInstantiator instantiator)
    {
      Config = config;
      Instantiator = instantiator;
    }

    public void Explode([NotNull] Transform target, Vector3 velocity, [NotNull] Sprite sprite, Material material = null)
      => Instantiator
        .InstantiateComponentPrefab(Config.ExplosionPrefab)
        .Explode(target, velocity, sprite, material);
  }
}