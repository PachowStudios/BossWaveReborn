using System;
using PachowStudios.BossWave.Projectiles;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Installers
{
  public partial class ProjectileInstaller
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public ProjectileComponents Components;
      public ProjectileMoveHandler.Settings MoveHandler;
    }
  }
}
