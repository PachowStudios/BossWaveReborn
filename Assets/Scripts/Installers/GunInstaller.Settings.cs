using System;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Installers
{
  public partial class GunInstaller
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public GunFacade.Settings Facade;
    }
  }
}