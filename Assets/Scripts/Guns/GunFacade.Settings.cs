using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Guns
{
  public partial class GunFacade
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public string Name;
      public GunRarity Rarity;
    }
  }
}
