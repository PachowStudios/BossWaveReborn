using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerMoveHandler
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public float WalkSpeed = 17f;
      public float RunSpeed = 23f;
      public float JumpHeight = 7.5f;
    }
  }
}