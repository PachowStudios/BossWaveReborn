using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Extensions;
using PachowStudios.BossWave.Projectiles;
using PachowStudios.Framework;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers.Global
{
  [AddComponentMenu("Boss Wave/Installers/Global/Projectile Factory Installer")]
  public class ProjectileFactoryInstaller : MonoInstaller
  {
    [Serializable, InstallerSettings]
    public class ProjectilePrefabMapping
    {
      public ProjectileType Type;
      public ProjectileFacade Prefab;
    }

    [SerializeField] private List<ProjectilePrefabMapping> projectiles = null;

    private IDictionary<ProjectileType, ProjectileFacade> Projectiles { get; set; }

    [Inject]
    public void Construct()
      => Projectiles = this.projectiles.ToDictionary(p => p.Type, p => p.Prefab);

    public override void InstallBindings()
    {
      Container
        .BindFactory<ProjectileType, ProjectileFacade, ProjectileFactory>()
        .FromSubContainerResolve()
        .ByPrefabLookup(Projectiles);

      if (Container.IsValidating)
        Validate();
    }

    private void Validate()
    {
      var missingMappings = EnumHelper
        .GetValues<ProjectileType>()
        .Where(t => !Projectiles.ContainsKey(t) || Projectiles[t] == null)
        .ToList();

      if (missingMappings.Any())
        throw new ZenjectException($"Projectiles are missing mappings: {missingMappings.ToValuesString()}");
    }
  }
}
