using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Projectiles
{
  public partial class ProjectileMoveHandler
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public float ShotSpeed = 25f;
      public float Gravity = 0f;
    }
  }
}
