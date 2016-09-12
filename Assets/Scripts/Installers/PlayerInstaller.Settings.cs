using System;
using PachowStudios.BossWave.Entity;
using PachowStudios.BossWave.Player;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Installers
{
  public partial class PlayerInstaller
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public PlayerComponents Components;
      public ExternalForces ExternalForces;
      public PlayerAnimationHandler.Settings AnimationHandler;
      public PlayerMoveHandler.Settings MoveHandler;
      public PlayerDamageHandler.Settings DamageHandler;
      public PlayerShootHandler.Settings ShootHandler;
      public PlayerGunSelector.Settings GunSelector;
    }
  }
}