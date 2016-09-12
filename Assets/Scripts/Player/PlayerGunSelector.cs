using System.Collections.Generic;
using System.Linq;
using PachowStudios.BossWave.Guns;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerGunSelector : IInitializable
  {
    private Settings Config { get; }
    private PlayerModel Model { get; }
    private GunFactory GunFactory { get; }

    private GunFacade CurrentGun
    {
      get { return Model.CurrentGun; }
      set { Model.CurrentGun = value; }
    }

    private List<GunFacade> Guns => Model.Guns;
    private int CurrentGunIndex => Guns.IndexOf(CurrentGun);

    public PlayerGunSelector(Settings config, PlayerModel model, GunFactory gunFactory)
    {
      Config = config;
      Model = model;
      GunFactory = gunFactory;
    }

    public void Initialize()
    {
      Config.StartingGuns.ForEach(AddGun);
      SelectGun(Guns.First());
    }

    private void AddGun(GunType type)
    {
      var gun = GunFactory.Create(type);

      gun.ParentTo(Model.GunPoint);
      gun.transform.localPosition = Vector3.zero;

      if (Guns.Count == Config.Capacity)
      {
        ReplaceCurrentGun(gun);
        return;
      }

      Guns.Add(gun);
    }

    private void ReplaceCurrentGun(GunFacade gun)
    {
      Guns[CurrentGunIndex] = gun;
      CurrentGun.Destroy();
      SelectGun(gun);
    }

    private void SelectGun(GunFacade gun)
    {
      if (CurrentGun != null)
        CurrentGun.IsActive = false;

      CurrentGun = gun;
      CurrentGun.IsActive = true;
    }
  }
}
