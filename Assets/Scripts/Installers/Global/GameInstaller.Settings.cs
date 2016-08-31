using System;
using InControl;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Installers.Global
{
  public partial class GameInstaller
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public InControlManager InControlManager;
    }
  }
}