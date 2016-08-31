using System;
using PachowStudios.Framework;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerAnimationHandler
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public Vector2 IdleActionInterval = new Vector2(3f, 6f);
    }
  }
}