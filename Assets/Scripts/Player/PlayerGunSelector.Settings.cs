using System;
using System.Collections.Generic;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework;
using UnityEngine;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerGunSelector
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public Transform GunPoint;
      public List<GunType> StartingGuns;
    }
  }
}