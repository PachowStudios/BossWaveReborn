using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Guns
{
  [AddComponentMenu("Boss Wave/Guns/Gun Facade")]
  public partial class GunFacade : MonoBehaviour
  {
    private Settings Config { get; set; }
    private GunModel Model { get; set; }

    public bool IsActive
    {
      get { return Model.IsActive; }
      set { Model.IsActive = value; }
    }

    public bool IsShooting
    {
      get { return Model.IsShooting; }
      set { Model.IsShooting = value; }
    }

    public Vector2 AimDirection
    {
      get { return Model.AimDirection; }
      set { Model.AimDirection = value; }
    }

    public string Name => Config.Name;
    public GunRarity Rarity => Config.Rarity;

    [Inject]
    public void Construct(Settings config, GunModel model)
    {
      Config = config;
      Model = model;

      name = Name;
    }
  }
}