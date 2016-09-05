using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Zenject
{
  public static class ZenjectExtensions
  {
    [NotNull]
    public static T InstantiateComponentPrefab<T>([NotNull] this IInstantiator instantiator, [NotNull] T prefab)
      where T : MonoBehaviour
      => instantiator.InstantiatePrefabForComponent<T>(prefab);

    [NotNull]
    public static ConditionBinder ByPrefabLookup<TKey, TPrefab>(
      [NotNull] this FactorySubContainerBinder<TKey, TPrefab> binder,
      IDictionary<TKey, TPrefab> prefabs)
      where TPrefab : UnityObject
      => binder.ByMethod((c, key) => c.Bind<TPrefab>().FromPrefab(prefabs[key]));
  }
}