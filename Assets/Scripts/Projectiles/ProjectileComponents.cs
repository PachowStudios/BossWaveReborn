using System;
using PachowStudios.Framework;
using PachowStudios.Framework.Movement;
using UnityEngine;

namespace PachowStudios.BossWave.Projectiles
{
  [Serializable, InstallerSettings]
  public class ProjectileComponents
  {
    public Transform Projectile;
    public MovementController2D MovementController;
    public SpriteRenderer Renderer;
  }
}
