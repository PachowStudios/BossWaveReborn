using System;
using PachowStudios.Framework;
using UnityEngine;

namespace PachowStudios.BossWave.Guns
{
  [Serializable, InstallerSettings]
  public class GunComponents
  {
    public Transform Gun;
    public Transform FirePoint;
    public SpriteRenderer Renderer;
    public SpriteRenderer MuzzleFlashRenderer;
  }
}
