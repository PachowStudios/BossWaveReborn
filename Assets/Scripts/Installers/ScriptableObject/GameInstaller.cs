using InControl;
using PachowStudios.Framework.Messaging;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [CreateAssetMenu(menuName = "Boss Wave/Installers/Game Installer")]
  public class GameInstaller : ScriptableObjectInstaller
  {
    [SerializeField] private InControlManager inControlManager;

    public override void InstallBindings()
    {
      Container.Bind<InControlManager>().FromPrefab(this.inControlManager).AsSingle().NonLazy();

      Container.BindAllInterfaces<EventAggregator>().To<EventAggregator>().AsSingle();
    }
  }
}