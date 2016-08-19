using JetBrains.Annotations;
using UnityEngine;

namespace Zenject
{
  public static class ZenjectExtensions
  {
    [NotNull]
    public static T InstantiateComponentPrefab<T>([NotNull] this IInstantiator instantiator, [NotNull] T prefab)
      where T : MonoBehaviour
      => instantiator.InstantiatePrefabForComponent<T>(prefab);
  }
}