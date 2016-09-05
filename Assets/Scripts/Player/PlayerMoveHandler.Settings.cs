using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerMoveHandler
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public float WalkSpeed = 10.6f;
      public float RunSpeed = 14.4f;
      public float JumpHeight = 4.7f;
    }
  }
}