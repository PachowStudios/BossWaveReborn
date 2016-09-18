using System;
using System.Collections.Generic;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerGunSelector
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public List<GunType> StartingGuns;
      public int Capacity = 2;
      public float SelectGunCooldown = 0.5f;
    }
  }
}