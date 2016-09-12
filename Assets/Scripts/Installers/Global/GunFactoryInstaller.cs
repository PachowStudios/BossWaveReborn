using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Extensions;
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

    private IDictionary<GunType, GunFacade> Guns { get; set; }

    [Inject]
    public void Construct()
      => Guns = this.guns.ToDictionary(g => g.Type, g => g.Prefab);

    public override void InstallBindings()
    {
      Container
        .BindFactory<GunType, GunFacade, GunFactory>()
        .FromSubContainerResolve()
        .ByPrefabLookup(Guns);

      if (Container.IsValidating)
        Validate();
    }

    private void Validate()
    {
      var missingMappings = EnumHelper
        .GetValues<GunType>()
        .Where(t => !Guns.ContainsKey(t) || Guns[t] == null)
        .ToList();

      if (missingMappings.Any())
        throw new ZenjectException($"Guns are missing mappings: {missingMappings.ToValuesString()}");
    }
  }
}
