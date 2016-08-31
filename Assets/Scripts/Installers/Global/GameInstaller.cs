using InControl;
using PachowStudios.Framework.Messaging;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers.Global
{
  [AddComponentMenu("Boss Wave/Installers/Global/Game Installer")]
  public partial class GameInstaller : MonoInstaller
  {
    [SerializeField] private Settings config = null;

    public override void InstallBindings()
    {
      Container.Bind<InControlManager>().FromPrefab(this.config.InControlManager).AsSingle().NonLazy();

      Container.BindAllInterfaces<EventAggregator>().To<EventAggregator>().AsSingle();
    }
  }
}