using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerFacade
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public PlayerExternalForceSettings ExternalForces;
      public PlayerAnimationHandler.Settings AnimationHandler;
      public PlayerMoveHandler.Settings MoveHandler;
      public PlayerHitHandler.Settings HitHandler;
    }
  }
}