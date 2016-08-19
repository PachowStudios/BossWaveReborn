using UnityEngine;

namespace PachowStudios.Framework.Effects
{
  [InstallerSettings, CreateAssetMenu(menuName = "Pachow Studios/Effects/Explode Effect Settings")]
  public class ExplodeEffectSettings : ScriptableObject
  {
    public ExplodeEffectView ExplosionPrefab;
    public float Duration = 5f;
    public float ParticleLifetime = 1f;
  }
}
