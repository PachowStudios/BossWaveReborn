using UnityEngine;

namespace PachowStudios.BossWave.Guns
{
  public partial class GunFacade : MonoBehaviour
  {
    private Settings Config { get; }
    private GunModel Model { get; }

    public bool IsActive
    {
      get { return Model.IsActive; }
      set { Model.IsActive = value; }
    }

    public string Name => Config.Name;

    public GunRarity Rarity => Config.Rarity;

    public GunFacade(Settings config, GunModel model)
    {
      Config = config;
      Model = model;

      name = Name;
    }
  }
}