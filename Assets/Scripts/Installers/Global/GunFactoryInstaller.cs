using System;
using System.Collections.Generic;
using System.Linq;
using PachowStudios.BossWave.Guns;
using PachowStudios.Framework;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers.Global
{
  [AddComponentMenu("Boss Wave/Installers/Global/Gun Factory Installer")]
  public class GunFactoryInstaller : MonoInstaller
  {
    [Serializable, InstallerSettings]
    public class GunPrefabMapping
    {
      public GunType Type;
      public GunFacade Prefab;
    }

    [SerializeField] private List<GunPrefabMapping> guns = null;

    public override void InstallBindings()
      => Container
        .BindFactory<GunType, GunFacade, GunFactory>()
        .FromSubContainerResolve()
        .ByPrefabLookup(this.guns.ToDictionary(g => g.Type, g => g.Prefab));
  }
}
